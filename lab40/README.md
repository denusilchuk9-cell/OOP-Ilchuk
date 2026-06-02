# Лабораторна робота №40: GitHub Actions CI/CD для .NET

**Виконавець:** Ільчук Денис  
**Репозиторій:** [OOP-Ilchuk/lab40](https://github.com/denusilchuk9-cell/OOP-Ilchuk/tree/lab40/lab40)

---

## 🚦 Статус CI/CD

| Workflow | Статус |
|----------|--------|
| CI (Build & Test) | [![CI](https://github.com/denusilchuk9-cell/OOP-Ilchuk/actions/workflows/ci.yml/badge.svg?branch=lab40)](https://github.com/denusilchuk9-cell/OOP-Ilchuk/actions/workflows/ci.yml) |
| Docker Build | [![Docker Build](https://github.com/denusilchuk9-cell/OOP-Ilchuk/actions/workflows/docker.yml/badge.svg?branch=lab40)](https://github.com/denusilchuk9-cell/OOP-Ilchuk/actions/workflows/docker.yml) |

---

## 📋 Мета роботи

Навчитися створювати GitHub Actions workflows для автоматизації збірки, тестування, перевірки якості коду та публікації .NET-застосунків.

---

## ✅ Виконання завдань

### 1️⃣ Базовий CI workflow

**Файл:** `.github/workflows/ci.yml`

**Тригери:**
- `push` до гілки `main` / `master`
- `pull_request` до гілки `main` / `master`
- `workflow_dispatch` (ручний запуск)

**Кроки:**
- Checkout коду
- Setup .NET
- Restore dependencies
- Build
- Test з coverage

---

### 2️⃣ Перевірка якості коду

Додано перевірки:
- `dotnet format --verify-no-changes` – перевірка форматування
- `dotnet build -warnaserror` – попередження як помилки

---

### 3️⃣ Coverage та артефакти
Артефакти: звіти coverage зберігаються 14 днів у вкладці Actions.

4️⃣ Matrix Strategy
Конфігурація:
strategy:
  matrix:
    os: [ubuntu-latest, windows-latest]
    dotnet-version: ['8.0.x']
    Результати (паралельні jobs):

ОС	.NET Version	Статус
Ubuntu Latest	8.0.x	✅ Success
Windows Latest	8.0.x	✅ Success
5️⃣ Docker Build Workflow
Файл: .github/workflows/docker.yml

Тригери:

Push до main / master

Push тегів v* (наприклад, v1.0.0)

Pull Request

Кроки:

Build Docker image

Smoke test (запуск контейнера)

Tag для release версій

6️⃣ Manual Release Workflow
Файл: .github/workflows/manual.yml

Запуск: Actions → Manual Release → Run workflow

Параметри:

version – версія релізу (наприклад, 1.0.0)

environment – staging / production

Що робить:

Build

Test

Publish

Upload artifact

📁 Структура проекту
MyApp_Lab40/
├── .github/workflows/
│   ├── ci.yml
│   ├── docker.yml
│   └── manual.yml
├── MyApp/
│   ├── MyApp.csproj
│   ├── Program.cs
│   └── Calculator.cs
├── MyApp.Tests/
│   ├── MyApp.Tests.csproj
│   └── CalculatorTests.cs
├── MyApp.sln
├── Dockerfile
└── README.md/
1. Чим відрізняється CI від CD?
CI (Continuous Integration) – автоматична збірка та тестування при кожній зміні. Реалізовано в ci.yml.

CD (Continuous Delivery) – автоматична доставка артефакту. Реалізовано через артефакти в manual.yml.

2. Навіщо потрібна matrix strategy?
Дозволяє перевірити сумісність коду з різними ОС та версіями .NET.

3. Що таке artifacts і навіщо зберігати coverage?
Artifacts – файли, що зберігаються після workflow. Coverage-звіти потрібні для аналізу якості тестування без локального запуску.

4. Як branch protection запобігає злиттю зламаного коду?
Вимога проходження required checks блокує merge, поки CI не пройде успішно.

5. Різниця між push, pull_request та workflow_dispatch?
push – автоматично при внесенні змін у гілку

pull_request – автоматично при створенні/оновленні PR

workflow_dispatch – ручний запуск через UI

6. Чому Docker build у CI корисний без деплою?
Перевіряє коректність Dockerfile

Гарантує, що образ збирається без помилок

Smoke test перевіряє базову працездатність
**Збір покриття:**
```yaml
dotnet test --collect:"XPlat Code Coverage" --results-directory ./coverage
