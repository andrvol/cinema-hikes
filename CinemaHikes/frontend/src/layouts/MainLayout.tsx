import { Layout, Menu, Button } from 'antd';
import { UserOutlined, SearchOutlined } from '@ant-design/icons';
import { Outlet } from 'react-router';
import type { ReactNode } from 'react';
import { useLocation, useNavigate } from 'react-router';

const {Header,Content,Footer} = Layout;
export const MainLayout = () => {
    const navigate = useNavigate();
    const location = useLocation();
    const menuItems = [
        {key:"/",label:"Home"},
        {key:"/catalog",label:"Catalog"},
        
    ];
    return (
        <Layout style={{minHeight:'100vh'}}>
        <Header style={{ display: 'flex', alignItems: 'center', padding: '0 40px' }}>
        <div style={{ 
          color: '#E50914', 
          fontSize: '24px', 
          fontWeight: 900, 
          letterSpacing: '1px',
          marginRight: '40px',
          cursor: 'pointer' 
        }}>
        CINEMAHIKES
        </div>
        <Menu
          theme="dark"
          mode="horizontal"
          selectedKeys={[location.pathname]}
          defaultSelectedKeys={['home']}
          items={menuItems}
          onClick={({key}) =>navigate(key)}
          style={{ flex: 1, borderBottom: 'none' }}
        />
        <div style={{display:'flex',gap:'16px',alignItems:'center'}}>
           <Button type="text" icon={<SearchOutlined style={{ fontSize: '18px', color: '#fff' }} />} />
          <Button type="text" icon={<UserOutlined style={{ fontSize: '18px', color: '#fff' }} />} />
        </div>
        </Header>
        <Content style={{ padding: '40px', maxWidth: '1440px', margin: '0 auto', width: '100%' }}>
            <Outlet /> {}
        </Content>
        <Footer style={{ textAlign: 'center', color: '#666' }}>
        CinemaHikes ©{new Date().getFullYear()} — FindYourMovie
        </Footer>
        </Layout>

    )
}