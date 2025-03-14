import React from 'react';
import ReactDOM from 'react-dom/client';
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
import './index.css'
import { Home } from './pages/home';
import { WaitTriage } from './pages/wait-triage';
import { Triage } from './pages/triage';


const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

const router = createBrowserRouter([
  {
    path: "/",
    element: <Home />,
  },
  {
    path: "/wait-triage",
    element: <WaitTriage />,
  },
  {
    path: "/triage",
    element: <Triage />
  }
]);

root.render(
  <React.StrictMode>
    <RouterProvider router={router} />  
  </React.StrictMode>
);