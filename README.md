cinema-hikes-frontend/
│
├── public/                      # Статика, которая не обрабатывается Webpack/Vite
│   ├── favicon.ico
│   └── assets/                  # Локальные заглушки (например, аватарка по умолчанию)
│
├── src/
│   │
│   ├── app/                     # 1. Инициализация и глобальные настройки
│   │   ├── providers/           
│   │   │   ├── AntdThemeProvider.tsx  # Настройка темной темы (Netflix style) через ConfigProvider
│   │   │   ├── AuthProvider.tsx       # Проверка токена при старте приложения
│   │   │   └── QueryProvider.tsx      # Настройка @tanstack/react-query (кэш запросов)
│   │   ├── router/              
│   │   │   ├── index.tsx              # Конфигурация react-router-dom
│   │   │   └── ProtectedRoute.tsx     # Защита роутов (редирект на логин, проверка UserRole)
│   │   ├── store/               
│   │   │   └── useAuthStore.ts        # Zustand: хранение JWT и данных текущего AppUser
│   │   ├── styles/              
│   │   │   └── global.css             # Глобальные сбросы и миксины (если не хватает antd)
│   │   └── App.tsx              # Корневой компонент (собирает провайдеры и роутер)
│   │
│   ├── layouts/                 # 2. Каркасы страниц (оболочки)
│   │   ├── MainLayout.tsx       # Клиентская часть: antd <Layout> + Navbar + Footer
│   │   ├── AdminLayout.tsx      # Админка: antd <Layout> + <Sider> (боковое меню)
│   │   └── AuthLayout.tsx       # Страницы входа: минималистичный фон для центрирования форм
│   │
│   ├── pages/                   # 3. Страницы (Только сборка фичей, минимум логики)
│   │   ├── public/              
│   │   │   ├── HomePage.tsx       # Слайдеры новинок, популярное
│   │   │   ├── CatalogPage.tsx    # Грид фильмов с фильтрацией (FR-01)
│   │   │   └── MoviePage.tsx      # Плеер, описание, отзывы (FR-03, FR-04)
│   │   ├── auth/                
│   │   │   ├── LoginPage.tsx      
│   │   │   └── RegisterPage.tsx   
│   │   ├── private/             
│   │   │   └── ProfilePage.tsx    # Личный кабинет (вкладки: Избранное, История)
│   │   └── admin/               
│   │       ├── DashboardPage.tsx  # Сводка и статистика (AdminAnalyticsController)
│   │       ├── MoviesMgmtPage.tsx # Таблица управления каталогом (CRUD)
│   │       └── UsersMgmtPage.tsx  # Управление правами (AdminUsersController)
│   │
│   ├── features/                # 4. Изолированные бизнес-модули (соответствуют сервисам C#)
│   │   ├── auth/                
│   │   │   ├── api/               # loginRequest, registerRequest
│   │   │   └── components/        # LoginForm, RegisterForm (на базе antd <Form>)
│   │   │
│   │   ├── catalog/             
│   │   │   ├── api/               # fetchMovies, fetchGenres (связь с MoviesController)
│   │   │   ├── hooks/             # useMoviesQuery, useGenresQuery
│   │   │   └── components/        # MovieFilterBar, MovieSearchInput, MovieCarousel
│   │   │
│   │   ├── movie-details/       
│   │   │   ├── api/               # fetchMovieDetails, fetchVideoSources
│   │   │   └── components/        # VideoPlayer, ReviewList (antd <List>), ReviewForm
│   │   │
│   │   ├── user-profile/        
│   │   │   ├── api/               # fetchFavorites, fetchHistory
│   │   │   └── components/        # FavoritesGrid, HistoryTimeline (antd <Timeline>)
│   │   │
│   │   └── admin/               
│   │       ├── api/               # admin CRUD методы
│   │       └── components/        # MoviesTable (antd <Table>), MovieEditModal (antd <Modal>)
│   │
│   ├── shared/                  # 5. Переиспользуемые технические и UI-модули
│   │   ├── api/                 
│   │   │   └── axiosClient.ts     # Базовый Axios + Interceptors (прикрепление JWT, обработка 401/403)
│   │   ├── types/                 # ⚠️ Точные копии ваших DTO из C# (interfaces)
│   │   │   ├── common.ts          # PaginatedResponse<T>
│   │   │   ├── enums.ts           # VideoQuality, SourceStatus, UserRole
│   │   │   └── dtos.ts            # MovieDetailsDto, MovieListItemDto и т.д.
│   │   ├── ui/                    # Глупые обертки над antd для соблюдения дизайн-кода проекта
│   │   │   ├── MovieCard/         # Карточка фильма (обертка над antd <Card>)
│   │   │   ├── GenreTag/          # Тег жанра (обертка над antd <Tag>)
│   │   │   └── PageSpinner.tsx    # Крутилка загрузки (antd <Spin>)
│   │   ├── hooks/               
│   │   │   └── useDebounce.ts     # Для оптимизации поиска (чтобы не спамить API при вводе)
│   │   └── utils/               
│   │       ├── dateUtils.ts       # Форматирование дат (через dayjs, который встроен в antd)
│   │       └── formatRuntime.ts   # Перевод минут в формат "1 ч 45 мин"
│   │
│   ├── main.tsx                 # Точка входа React
│   └── vite-env.d.ts            # Типизация Vite
│
├── .env                         # VITE_API_URL=https://localhost:5001/api
├── package.json
├── tsconfig.json
└── vite.config.ts               # Настройки сборщика, алиасы путей (@/features, @/shared)
