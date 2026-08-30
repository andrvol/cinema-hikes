import { Typography, Button, Space } from 'antd';
import { PlayCircleOutlined } from '@ant-design/icons';
import { AntdThemeProvider } from './providers/AntdThemeProvider';
import { Router } from 'react-router';
import {router} from './routers/index'
import './styles/global.css';
import { RouterProvider } from 'react-router';

export function App() {
  return (
    <AntdThemeProvider>
      <RouterProvider router={router} />
    </AntdThemeProvider>
  )
}