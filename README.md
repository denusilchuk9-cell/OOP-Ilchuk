# Лабораторна робота №7: Обробка IO/мережевих помилок та патерн Retry

## Мета
Навчитися обробляти типові помилки вводу/виводу та мережеві помилки за допомогою блоків try-catch-finally, а також реалізувати патерн Retry для підвищення відмовостійкості застосунків.

## Варіант: Отримання списку користувачів
- **FileProcessor**: Метод `LoadUsernames` імітує IOException перші 3 рази, потім успіх.
- **NetworkClient**: Метод `GetUsersFromApi` імітує HttpRequestException перші 2 рази, потім успіх.
- **shouldRetry**: Повторювати тільки для IOException та HttpRequestException.

## Структура проєкту
- `Program.cs`: Демонстрація в Main.
- `FileProcessor.cs`: Імітація файлових операцій.
- `NetworkClient.cs`: Імітація мережевих запитів.
- `RetryHelper.cs`: Узагальнений клас з патерном Retry та експоненційною затримкою.

## Як запустити
1. Встановіть .NET SDK (якщо немає): [dotnet.microsoft.com](https://dotnet.microsoft.com/download)
2. Клонуйте репозиторій: `git clone https://github.com/твій_юзернейм/OOP-Ilchuk.git`
3. Перейдіть у папку: `cd lab7v1`
4. Компілюйте: `dotnet build`
5. Запустіть: `dotnet run`

## Очікуваний вивід