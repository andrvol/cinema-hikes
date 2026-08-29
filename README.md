# cinema-hikes

## Architecture

### ⚙️ Backend

```
CinemaHikes.slnx
│
├── src/
│   ├── CinemaHikes.Domain/
│   │   ├── Entities/
│   │   │   ├── Users/
│   │   │   │   ├── FavoriteMovie.cs            # : IUserMovieRelation
│   │   │   │   └── ViewHistoryEntry.cs         # : IUserMovieRelation
│   │   │   │
│   │   │   └── Catalog/                        # Каталог фильмов — без актёров/каста
│   │   │       ├── Movie.cs
│   │   │       ├── Genre.cs
│   │   │       ├── MovieGenre.cs                # join-таблица
│   │   │       ├── VideoSource.cs               # плеер/источник: PageUrl на сайт-источник (FR-04)
│   │   │       ├── MovieLink.cs                 # MovieId, Quality, Url — прямая ссылка (FR-06), обычная таблица без TTL
│   │   │       └── Review.cs
│   │   │
│   │   ├── Enums/
│   │   │   ├── SourceStatus.cs                  # Active, Dead, Checking
│   │   │   ├── VideoQuality.cs                  # Q360, Q480, Q720, Q1080
│   │   │   ├── ReviewStatus.cs                  # Pending, Approved, Rejected
│   │   │   └── UserRole.cs                      # Guest, User, Admin
│   │   │
│   │   ├── Interfaces/                          # Порты (реализуются в Infrastructure)
│   │   │   ├── Repositories/
│   │   │   │   ├── IMovieRepository.cs
│   │   │   │   ├── IGenreRepository.cs
│   │   │   │   ├── IVideoSourceRepository.cs
│   │   │   │   ├── IMovieLinkRepository.cs           # обычный CRUD над movie_links
│   │   │   │   ├── IReviewRepository.cs
│   │   │   │   ├── IUserMovieRelationRepository.cs   # generic<T> — Favorite/History
│   │   │   │   └── IParsingSourceRepository.cs
│   │   │   ├── IUserMovieRelation.cs
│   │   │   ├── IUnitOfWork.cs
│   │   │   ├── IJwtTokenService.cs
│   │   │   ├── ICurrentUserService.cs
│   │   │   │
│   │   │   └── Bot/                              # ↓ порты бота — реальные имена из вашего репозитория
│   │   │       ├── IBrowserConfig.cs             # CreateLaunchOptions() / CreateContextOptions()
│   │   │       ├── IBrowserFactory.cs            # CreatePageAsync(IBrowserConfig) / DisposeAsync()
│   │   │       ├── IFilmParserFacade.cs          # GetFilmSrc(pageUrl, videoQuality)
│   │   │       ├── IPageConfig.cs                # InitPageAsync(page, pageUrl)
│   │   │       ├── Parsers/
│   │   │       │   ├── IFilmUrlParser.cs         # GetFilmUrlAsync(page, videoQuality)
│   │   │       │   └── IPageElementParser.cs     # ParseElementAsync(page)
│   │   │       ├── ITelegramFileSender.cs        # SendVideoAsync / SendLinkAsync
│   │   │       └── IVideoSizeChecker.cs          # лимит 2GB (A-03/R-02)
│   │   │
│   │   └── Specifications/
│   │       ├── MovieFilterSpecification.cs      # жанр/год/рейтинг (FR-01)
│   │       ├── MovieSearchSpecification.cs      # поиск по названию (FR-02)
│   │       └── ActiveSourcesSpecification.cs    # NFR-05: >=2 живых источника
│   │
│   ├── CinemaHikes.Application/
│   │   ├── Services/
│   │   │   ├── MovieService.cs                  # FR-01, FR-02, FR-03, FR-04
│   │   │   ├── MovieDownloadService.cs          # FR-06 — ключевой сервис бота (см. ниже)
│   │   │   ├── TelegramSearchService.cs         # FR-05 — поиск для inline-кнопок бота
│   │   │   ├── GenreService.cs
│   │   │   ├── AuthService.cs                   # FR-08
│   │   │   ├── FavoriteService.cs
│   │   │   ├── ViewHistoryService.cs
│   │   │   ├── ReviewService.cs
│   │   │   ├── AdminMovieService.cs             # CRUD фильмов/жанров
│   │   │   └── AdminAnalyticsService.cs         # агрегаты по ViewHistoryEntry/Review
│   │   │
│   │   ├── DTOs/
│   │   │   ├── Catalog/
│   │   │   │   ├── MovieListItemDto.cs
│   │   │   │   ├── MovieDetailsDto.cs
│   │   │   │   ├── VideoSourceDto.cs
│   │   │   │   ├── GenreDto.cs
│   │   │   │   └── ReviewDto.cs
│   │   │   ├── Auth/
│   │   │   │   ├── RegisterRequestDto.cs
│   │   │   │   ├── LoginRequestDto.cs
│   │   │   │   └── AuthResponseDto.cs
│   │   │   ├── User/
│   │   │   │   ├── FavoriteDto.cs
│   │   │   │   └── ViewHistoryDto.cs
│   │   │   └── Bot/
│   │   │       ├── TelegramMovieResultDto.cs
│   │   │       └── DownloadResultDto.cs          # File(url) | Link(url)
│   │   │
│   │   ├── Validators/
│   │   │   ├── RegisterRequestValidator.cs      # пароль >= 6 символов (FR-08 AC)
│   │   │   ├── MovieCreateValidator.cs
│   │   │   └── ParsingSourceValidator.cs
│   │   │
│   │   └── Mappings/
│   │       ├── MovieProfile.cs
│   │       └── UserProfile.cs
│   │
│   ├── CinemaHikes.Infrastructure/
│   │   │
│   │   ├── DependencyInjection.cs
│   │   │
│   │   ├── Persistence/
│   │   │   ├── CinemaHikesDbContext.cs
│   │   │   ├── Configurations/
│   │   │   │   ├── MovieConfiguration.cs
│   │   │   │   ├── GenreConfiguration.cs
│   │   │   │   ├── VideoSourceConfiguration.cs
│   │   │   │   ├── MovieLinkConfiguration.cs     # unique index (MovieId, Quality)
│   │   │   │   └── ...
│   │   │   └── Migrations/
│   │   │
│   │   ├── Identity/
│   │   │   ├── AppUser.cs : IdentityUser<Guid>
│   │   │   └── IdentityConfig.cs
│   │   │
│   │   ├── Repositories/
│   │   │   ├── Catalog/
│   │   │   │   ├── MovieRepository.cs
│   │   │   │   ├── GenreRepository.cs
│   │   │   │   ├── VideoSourceRepository.cs
│   │   │   │   ├── MovieLinkRepository.cs        # GetByMovieAndQuality, Upsert
│   │   │   │   └── ReviewRepository.cs
│   │   │   ├── Users/
│   │   │   │   └── UserMovieRelationRepository.cs   # generic<T> where T : class, IUserMovieRelation
│   │   │   ├── Parsing/
│   │   │   │   └── ParsingSourceRepository.cs
│   │   │   └── UnitOfWork.cs
│   │   │
│   │   ├── Bot/                                  # ↓ реализация — 1:1 с вашим репозиторием
│   │   │   ├── Configs/
│   │   │   │   ├── BrowserProfileConfig.cs        # record: UserAgent, Platform, Viewport, Locale, TimezoneId
│   │   │   │   ├── RandomBrowserConfig.cs         # : IBrowserConfig — headless Chromium args
│   │   │   │   └── RezkaPageConfig.cs             # : IPageConfig — GotoAsync + WaitForTimeout
│   │   │   │
│   │   │   ├── Facades/
│   │   │   │   └── RezkaFilmParserFacade.cs       # : IFilmParserFacade — оркестрирует парсинг страницы
│   │   │   │
│   │   │   ├── Factories/
│   │   │   │   └── PlaywrightBrowserFactory.cs    # : IBrowserFactory — Chromium.LaunchAsync + anti-detect script
│   │   │   │
│   │   │   ├── Parsers/
│   │   │   │   └── Rezka/
│   │   │   │       ├── RezkaFilmUrlParser.cs           # : IFilmUrlParser — клик по качеству, чтение <video src>
│   │   │   │       ├── RezkaGearIconParser.cs          # : IPageElementParser — клик по шестерёнке плеера
│   │   │   │       └── RezkaVideoQualityMenuParser.cs  # : IPageElementParser — открывает меню качества
│   │   │   │
│   │   │   ├── Providers/
│   │   │   │   └── BrowserProfileProvider.cs      # статический пул реалистичных профилей браузера (anti-bot)
│   │   │   │
│   │   │   └── Telegram/
│   │   │       ├── TelegramFileSender.cs          # : ITelegramFileSender (Telegram.Bot, SendVideo/SendMessage)
│   │   │       └── VideoSizeChecker.cs            # : IVideoSizeChecker (HEAD-запрос на прямую ссылку)
│   │   │
│   │   ├── BackgroundJobs/
│   │   │   └── RevalidateMovieLinksJob.cs        # перепроверка "протухших" ссылок в movie_links
│   │   │
│   │   └── Security/
│   │       ├── JwtTokenService.cs
│   │       └── CurrentUserService.cs
│   │
│   ├── CinemaHikes.WebApi/
│   │   ├── Controllers/
│   │   │   ├── AuthController.cs
│   │   │   ├── MoviesController.cs
│   │   │   ├── GenresController.cs
│   │   │   ├── FavoritesController.cs
│   │   │   ├── HistoryController.cs
│   │   │   ├── ReviewsController.cs
│   │   │   └── Admin/
│   │   │       ├── AdminMoviesController.cs
│   │   │       ├── AdminUsersController.cs
│   │   │       └── AdminAnalyticsController.cs
│   │   ├── Middleware/
│   │   │   └── ExceptionHandlingMiddleware.cs
│   │   └── Program.cs
│   │
│   └── CinemaHikes.TelegramBotDownloader/        # ⭐ основной проект — расширяет ваш текущий Program.cs
│       ├── .example.env
│       ├── Handlers/
│       │   ├── SearchTextHandler.cs              # текст → TelegramSearchService (FR-05)
│       │   ├── MovieSelectedCallbackHandler.cs   # выбор фильма → карточка + кнопки качества
│       │   └── DownloadCallbackHandler.cs        # выбор качества → MovieDownloadService (FR-06)
│       ├── RateLimiting/
│       │   └── TelegramRateLimiter.cs            # NFR-03, ConcurrentDictionary<long, DateTime>, in-memory
│       └── Program.cs                             # DI, TelegramBotClient, OnMessage/OnUpdate
│
└── tests/
    ├── CinemaHikes.Domain.UnitTests/
    ├── CinemaHikes.Application.UnitTests/
    ├── CinemaHikes.WebApi.IntegrationTests/
    └── CinemaHikes.TelegramBot.IntegrationTests/
```

### 📃 Frontend

```
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
```
