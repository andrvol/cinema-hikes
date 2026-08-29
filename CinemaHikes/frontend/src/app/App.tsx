import { Typography, Button, Space } from 'antd';
import { PlayCircleOutlined } from '@ant-design/icons';
import { AntdThemeProvider } from './providers/AntdThemeProvider';
import { MainLayout } from '../layouts/MainLayout';
import './styles/global.css';
const {Title,Paragraph}= Typography;
export function App() {
  return (
    <AntdThemeProvider>
      <MainLayout>
        <div style={{marginTop:"50px"}}>
          <Title style={{ fontSize: '48px', marginBottom: '8px' }}>Cinema with no limits</Title>
          <Paragraph style={{ fontSize: '18px', color: '#999', maxWidth: '600px' }}>
            Be safe..Be free..
          </Paragraph>
          <Space size="middle" style={{ marginTop: '24px' }}>
            <Button type="primary" size="large" icon={<PlayCircleOutlined />}>
              Смотреть новинки
            </Button>
            <Button size="large" type="default">
              Каталог
            </Button>
          </Space>
        </div>
        
      </MainLayout>
    </AntdThemeProvider>
  )
}