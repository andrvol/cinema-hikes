import { createBrowserRouter } from "react-router";
import { CatalogPage } from "../../pages/public/CatalogPage";
import { HomePage } from "../../pages/public/HomePage";
import { MainLayout } from "../../layouts/MainLayout";

export const router = createBrowserRouter([{path:'/',element:<MainLayout/>,children: [
      { index: true, element: <HomePage /> }, 
      { path: 'catalog', element: <CatalogPage /> },
    ]}]);