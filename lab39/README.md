
# Лабораторна робота №39: GitHub: робота в команді

**Студент:** [Ваше ПІБ]  
**GitHub репозиторій:** [Посилання на ваш репозиторій]  
**.NET проєкт:** [Назва проєкту, наприклад, OrderManagementSystem]  

---

## Мета роботи
Опанувати професійний workflow роботи з Git та GitHub: створення гілок за стратегією, оформлення pull requests, проведення code review, вирішення merge-конфліктів та організація командної роботи через Issues та Projects.

---

## Виконання завдань

### 1. Налаштування репозиторію для командної роботи

- **Branch protection rule для `main`:**
    - Увімкнено вимогу pull request перед merge.
    - Увімкнено вимогу щонайменше 1 approval (для роботи в парі).
    - Вимогу CI checks налаштовано (проект компілюється без помилок).

- **PR шаблон** (`.github/PULL_REQUEST_TEMPLATE.md`): створено, містить секції Summary, Related Issue, Changes, Checklist.

- **Issue шаблони:**
    - `.github/ISSUE_TEMPLATE/bug_report.md`
    - `.github/ISSUE_TEMPLATE/feature_request.md`

---

### 2. Створення Issues (4 шт.)

| # | Заголовок | Тип | Мітки | Критерії прийняття |
|---|-----------|-----|-------|--------------------|
| 1 | Додати CSV експорт історії замовлень | Feature | `enhancement` | Можливість експорту у CSV; фільтрація за датою; покриття тестами |
| 2 | Додати валідацію email при створенні клієнта | Feature | `enhancement` | Перевірка формату email; повідомлення про помилку |
| 3 | NullReferenceException у методі CalculateTotal | Bug | `bug` | Відтворюється при пустому кошику; виправити з перевіркою на null |
| 4 | Рефакторинг OrderService: виділити інтерфейс | Refactor | `refactor` | Створити IOrderService; застосувати Dependency Injection |

> Посилання на Issues: [https://github.com/your-repo/issues](https://github.com/your-repo/issues) *(замінити на реальне посилання)*

---

### 3. Реалізація змін через feature branches

Для кожного Issue створено окрему гілку з дотриманням конвенції та Conventional Commits:

| Issue # | Назва гілки | Commit приклад |
|---------|-------------|----------------|
| #1 | `feature/add-csv-export` | `feat: add CSV export service for order history` |
| #2 | `feature/add-email-validation` | `feat: add email validation on customer creation` |
| #3 | `fix/null-reference-in-calculatetotal` | `fix: handle null cart in CalculateTotal method` |
| #4 | `refactor/extract-order-service-interface` | `refactor: extract IOrderService interface for DI` |

Код змінено (від 10 до 30 рядків на гілку), кожна гілка стосується лише одного Issue.

---

### 4. Оформлення Pull Requests (PR)

Створено **4 PR** (по одному на гілку). Кожен PR містить:
- Заповнений шаблон (Summary, Related Issue, Changes, Checklist).
- Посилання `Closes #N` на відповідний Issue.
- Мітки (`enhancement`, `bug`, `refactor`).
- Рецензента (реальна людина – одногрупник або викладач).

**Приклад PR:**  
[#1 Add CSV export for order history](https://github.com/your-repo/pull/1) *(замінити посилання)*

Перед створенням PR переглянуто diff, зайвих файлів немає.

---

### 5. Проведення Code Review

Я виконав review для **2 PR одногрупника** (реальна людина, не AI).

**Приклад коментарів (на одному з PR):**

1. **suggestion**: Цей метод порушує Single Responsibility Principle – краще розділити валідацію та збереження.  
   ```suggestion
   public ValidationResult Validate(Order order) { ... }
   public async Task SaveAsync(Order order) { ... }
   question: Чому використовується синхронний метод StreamReader замість асинхронного? Це може блокувати потік.

nitpick: Ім'я змінної tmpData не дуже інформативне. Запропонуйте exportedRecords або orderDataList.

Загальний Review Summary:
Після врахування зауважень – Approve.

6. Вирішення merge-конфлікту
Штучне створення конфлікту:
Змінено один і той самий рядок у файлі OrderService.cs в гілках feature/add-csv-export та feature/add-email-validation.

Процес вирішення (локально):
git checkout feature/add-csv-export
git merge main
# Виник конфлікт у OrderService.cs
# Відкрито файл, залишено обидві зміни (об'єднано)
git add src/Services/OrderService.cs
git commit -m "fix: resolve merge conflict in OrderService by combining both changes"
git push
Результат: PR успішно об'єднано після вирішення конфлікту.
(Скріншот процесу або посилання на PR з конфліктом додається)
7. Оформлення CONTRIBUTING.md
Створено файл CONTRIBUTING.md у корені проєкту. Він містить:

Branching strategy – GitHub Flow: main завжди стабільний, для змін – гілки feature/, fix/, refactor/.

Commit conventions – Conventional Commits: feat:, fix:, refactor:, docs:, etc.

Як створити PR – шаблон, посилання на Issue, checklist, призначення рецензента.

Як проводити code review – типи коментарів (suggestion, question, nitpick), використання GitHub Suggestions.

Як вирішувати конфлікти – локальний merge, редагування, git add/commit/push.

Файл доступний за посиланням: CONTRIBUTING.md
