import { createBrowserRouter } from "react-router-dom";

import { CatalogPage } from "../../pages/public/CatalogPage";
import { HomePage } from "../../pages/public/HomePage";
import { MainLayout } from "../../layouts/MainLayout";
import { AboutPage } from "../../pages/public/AboutPage";
import { DeveloperPage } from '../../pages/public/DeveloperPage';
import { NotFoundPage } from "../../pages/public/NotFoundPage";
export const router = createBrowserRouter([
  {
    path: "/",
    element: <MainLayout />,
    children: [
      { index: true, element: <HomePage /> },
      { path: "catalog", element: <CatalogPage /> },
      { path: "about", element: <AboutPage /> },
      { path: 'developer/:username', element: <DeveloperPage /> },
      {path:"*",element:<NotFoundPage/>},
    ],
  },
]);
