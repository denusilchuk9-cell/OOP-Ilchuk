# Лабораторна робота №28

**Тема:** Серіалізація об'єктів у JSON

**Мета:** Навчитися серіалізувати та десеріалізувати складні об'єкти у форматі JSON, зберігати дані у файли та завантажувати їх.

**Варіант:** №7 (Task, Project, TaskRepository)

---

## Умова завдання

1. Створити консольний проєкт `lab28v7`.
2. Реалізувати класи предметної області згідно з варіантом (3-5 класів).
3. Реалізувати репозиторій з JSON-серіалізацією:
   - Метод `SaveToFile(string filename)`
   - Метод `LoadFromFile(string filename)`
   - Метод `Add()`
   - Метод `GetAll()`
   - Метод `GetById(int id)`
4. Продемонструвати роботу в Main:
   - Створити кілька об'єктів
   - Зберегти у файл JSON
   - Завантажити з файлу
   - Вивести результат

---

## Структура проєкту
lab28v7/
│
├── Models/
│ ├── Project.cs # Клас проекту
│ └── WorkTask.cs # Клас задачі
│
├── Repositories/
│ └── TaskRepository.cs # Репозиторій з JSON серіалізацією
│
├── Program.cs # Головний файл з демонстрацією
├── packages.config # NuGet залежності
└── projects.json # Файл збережених даних

---

## Реалізовані класи

### Клас WorkTask (Модель задачі)

| Властивість | Тип | Опис |
|-------------|-----|------|
| Id | int | Унікальний ідентифікатор |
| Title | string | Назва задачі |
| Description | string | Опис задачі |
| IsCompleted | bool | Статус виконання |
| Priority | int | Пріоритет (1 - найвищий) |

### Клас Project (Модель проекту)

| Властивість | Тип | Опис |
|-------------|-----|------|
| Id | int | Унікальний ідентифікатор |
| Name | string | Назва проекту |
| Description | string | Опис проекту |
| CreatedDate | DateTime | Дата створення |
| Tasks | List\<WorkTask\> | Список задач проекту |

---

## Реалізовані методи репозиторію

| Метод | Опис |
|-------|------|
| `Add(Project project)` | Додає новий проект |
| `AddTaskToProject(int projectId, WorkTask task)` | Додає задачу до проекту |
| `GetAll()` | Повертає всі проекти |
| `GetById(int id)` | Повертає проект за ID |
| `SaveToFile(string filename)` | Зберігає дані у JSON файл |
| `LoadFromFile(string filename)` | Завантажує дані з JSON файлу |

---

## Використані технології

- **Мова програмування:** C#
- **Платформа:** .NET Framework 4.8
- **Бібліотека для JSON:** Newtonsoft.Json (v13.0.3)
- **Середовище розробки:** Visual Studio 2022

---

## Демонстрація роботи

### Вхідні дані

Створено 2 проекти:

1. **Website Redesign** (3 задачі)
   - Design mockups (Priority: 1)
   - Develop frontend (Priority: 2)
   - Testing (Priority: 3)

2. **Mobile App** (2 задачі)
   - API development (Priority: 1)
   - UI/UX design (Priority: 2)

### Вивід програми
<img width="1319" height="955" alt="image" src="https://github.com/user-attachments/assets/7baef2cd-4555-44f3-a698-bee13f1f40e1" />

<img width="663" height="89" alt="image" src="https://github.com/user-attachments/assets/53acc862-74f5-435f-ab63-f1a684940756" />

