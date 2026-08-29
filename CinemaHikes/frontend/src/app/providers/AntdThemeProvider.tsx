import {ConfigProvider,theme} from 'antd';
import type{ReactNode} from 'react';

export const AntdThemeProvider = ({children}:{children:ReactNode}) => {
    return(
        <ConfigProvider theme={{algorithm:theme.darkAlgorithm,token:{
            colorPrimary: '#E50914',
            colorBgBase: '#141414',
            colorTextBase: '#ffffff',
            borderRadius: 6,
        },
        components:{Layout:{
            headerBg: '#00000',
            bodyBg: '#141414',
            footerBg: '#00000',
        },
        Menu: {
            darkItemBg: '#00000',
        }
      }
    }}
    >{children}</ConfigProvider>
    )
}