import { HubConnection, HubConnectionBuilder, LogLevel } from "@microsoft/signalr";

export const newConnection = (name: string):HubConnection  => {
  const connection = new HubConnectionBuilder()
  .withUrl(`http://localhost:5184/hub/${name}`)
  .configureLogging(LogLevel.Information)
  .build();
  return connection;
}