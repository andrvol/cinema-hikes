import { AntdThemeProvider } from './providers/AntdThemeProvider';
import { RouterProvider } from 'react-router-dom';
import { router } from './routers/index';
import './styles/global.css';

export function App() {
  return (
    <AntdThemeProvider>
      <RouterProvider router={router} />
    </AntdThemeProvider>
  );
}