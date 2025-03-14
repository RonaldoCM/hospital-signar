import axios from "axios";
const api = axios.create({
  baseURL: 'http://localhost:5184/api',
});

export async function get<T>(
  path: string,
  successAction?: () => Promise<void> | void,
  failedAction?: () => Promise<void> | void
): Promise<T | undefined> {
  try {
    const response = (await api.get<T>(path))
    successAction && successAction();
    return response.data; 
  } catch (error: any) {
    failedAction && failedAction();
  }
}

export async function post<T>(
  path: string, 
  data?: unknown,
  successAction?: (response: T) => Promise<void> | void,
  failedAction?: () => Promise<void> | void
): Promise<void> {
  try {
    const response = (await api.post<T>(path, data)); 
    if(response.status === 200 || response.status === 201)
      successAction && successAction(response.data);
  } catch (error: any) {
    failedAction && failedAction();
  }
}