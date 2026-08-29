import { Layout, Menu, Button } from 'antd';
import { UserOutlined, SearchOutlined } from '@ant-design/icons';
import type { ReactNode } from 'react';

const {Header,Content,Footer} = Layout;
export const MainLayout = ({children}:{children:ReactNode}) => {
    const menuItems = [
        {key:"home",label:"Home"},
        {key:"catalog",label:"Catalog"},
        {key:"series",label:"Series"},
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
          defaultSelectedKeys={['home']}
          items={menuItems}
          style={{ flex: 1, borderBottom: 'none' }}
        />
        <div style={{display:'flex',gap:'16px',alignItems:'center'}}>
           <Button type="text" icon={<SearchOutlined style={{ fontSize: '18px', color: '#fff' }} />} />
          <Button type="text" icon={<UserOutlined style={{ fontSize: '18px', color: '#fff' }} />} />
        </div>
        </Header>
        <Content style={{ padding: '40px', maxWidth: '1440px', margin: '0 auto', width: '100%' }}>
            {children}
        </Content>
        <Footer style={{ textAlign: 'center', color: '#666' }}>
        CinemaHikes ©{new Date().getFullYear()} — FindYourMovie
        </Footer>
        </Layout>

    )
}