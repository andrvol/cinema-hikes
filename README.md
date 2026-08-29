cinema-hikes-frontend/
├── public/
│   ├── assets/
│   └── favicon.ico
├── src/
│   ├── app/
│   │   ├── providers/
│   │   │   ├── AntdThemeProvider.tsx
│   │   │   ├── AuthProvider.tsx
│   │   │   └── QueryProvider.tsx
│   │   ├── router/
│   │   │   ├── index.tsx
│   │   │   └── ProtectedRoute.tsx
│   │   ├── store/
│   │   │   └── useAuthStore.ts
│   │   ├── styles/
│   │   │   └── global.css
│   │   └── App.tsx
│   ├── features/
│   │   ├── admin/
│   │   │   ├── api/
│   │   │   └── components/
│   │   ├── auth/
│   │   │   ├── api/
│   │   │   └── components/
│   │   ├── catalog/
│   │   │   ├── api/
│   │   │   ├── components/
│   │   │   └── hooks/
│   │   ├── movie-details/
│   │   │   ├── api/
│   │   │   └── components/
│   │   └── user-profile/
│   │       ├── api/
│   │       └── components/
│   ├── layouts/
│   │   ├── AdminLayout.tsx
│   │   ├── AuthLayout.tsx
│   │   └── MainLayout.tsx
│   ├── pages/
│   │   ├── admin/
│   │   │   ├── DashboardPage.tsx
│   │   │   ├── MoviesMgmtPage.tsx
│   │   │   └── UsersMgmtPage.tsx
│   │   ├── auth/
│   │   │   ├── LoginPage.tsx
│   │   │   └── RegisterPage.tsx
│   │   ├── private/
│   │   │   └── ProfilePage.tsx
│   │   └── public/
│   │       ├── CatalogPage.tsx
│   │       ├── HomePage.tsx
│   │       └── MoviePage.tsx
│   ├── shared/
│   │   ├── api/
│   │   │   └── axiosClient.ts
│   │   ├── hooks/
│   │   │   └── useDebounce.ts
│   │   ├── types/
│   │   │   ├── common.ts
│   │   │   ├── dtos.ts
│   │   │   └── enums.ts
│   │   ├── ui/
│   │   │   ├── GenreTag/
│   │   │   ├── MovieCard/
│   │   │   └── PageSpinner.tsx
│   │   └── utils/
│   │       ├── dateUtils.ts
│   │       └── formatRuntime.ts
│   ├── main.tsx
│   └── vite-env.d.ts
├── .env
├── package.json
├── tsconfig.json
└── vite.config.ts
