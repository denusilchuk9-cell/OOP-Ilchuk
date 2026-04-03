# Самостійна робота №19

**Тема:** Фабрики + Singleton: заміна без змін клієнта

**Мета:** Навчитися застосовувати патерни Factory Method та Singleton для створення гнучкої системи, де клієнтський код залежить від абстракцій, а не від конкретних реалізацій, що дозволяє легко замінювати компоненти без зміни клієнта.

**Варіант:** №7 (Система валідації: Email, Password, Phone)

---

## Умова завдання

1. Створити новий консольний проєкт `IndependentWork19`.
2. Реалізувати систему валідації згідно з варіантом, використовуючи Factory Method та Singleton:
   - Інтерфейс `IValidator` з методом `bool Validate(string input)`
   - Кілька реалізацій `IValidator` (Email, Password, Phone)
   - Абстрактний клас `ValidatorFactory` з методом `CreateValidator()`
   - Конкретні фабрики для кожного типу валідатора
   - Клас `ValidationService` (Singleton) для керування поточною фабрикою
3. Продемонструвати роботу в методі `Main`:
   - Отримати екземпляр Singleton
   - Змінювати фабрики та виконувати валідацію

---

## Структура проєкту
IndependentWork19/
│
├── Models/
│ ├── IValidator.cs # Інтерфейс валідатора
│ ├── EmailValidator.cs # Валідатор email
│ ├── PasswordValidator.cs # Валідатор пароля
│ └── PhoneValidator.cs # Валідатор телефону
│
├── Factories/
│ ├── ValidatorFactory.cs # Абстрактна фабрика
│ ├── EmailValidatorFactory.cs # Фабрика для Email
│ ├── PasswordValidatorFactory.cs # Фабрика для Password
│ └── PhoneValidatorFactory.cs # Фабрика для Phone
│
├── Services/
│ └── ValidationService.cs # Singleton сервіс
│
└── Program.cs # Головний файл з демонстрацією

---

## Реалізовані класи

### Інтерфейс IValidator

| Метод | Опис |
|-------|------|
| `bool Validate(string input)` | Виконує валідацію вхідного рядка |
| `string GetErrorMessage()` | Повертає повідомлення про помилку |

### Класи-валiдатори

| Клас | Призначення | Правила валідації |
|------|-------------|-------------------|
| `EmailValidator` | Перевірка email | Містить @ та ., не пустий |
| `PasswordValidator` | Перевірка пароля | Мінімум 8 символів, велика/мала літера, цифра |
| `PhoneValidator` | Перевірка телефону | 10-13 цифр, український формат |

### Абстрактна фабрика ValidatorFactory

| Метод | Опис |
|-------|------|
| `abstract IValidator CreateValidator()` | Створює конкретний екземпляр валідатора |
| `void ValidateMessage(string input)` | Виконує валідацію та виводить результат |

### Конкретні фабрики

| Фабрика | Створює |
|---------|---------|
| `EmailValidatorFactory` | `EmailValidator` |
| `PasswordValidatorFactory` | `PasswordValidator` |
| `PhoneValidatorFactory` | `PhoneValidator` |

### Singleton: ValidationService

| Метод | Опис |
|-------|------|
| `GetInstance()` | Повертає єдиний екземпляр класу |
| `SetValidatorFactory(ValidatorFactory factory)` | Змінює поточну фабрику |
| `Validate(string input)` | Виконує валідацію через поточну фабрику |

---

## Діаграма класів
┌─────────────────┐ ┌─────────────────────┐
│ <<interface>> │ │ ValidationService │
│ IValidator │ │ (Singleton) │
├─────────────────┤ ├─────────────────────┤
│ +Validate() │ │ -instance │
│ +GetErrorMessage│◄─────── │ +GetInstance() │
└────────┬────────┘ │ +SetValidatorFactory│
│ │ +Validate() │
│ └──────────┬──────────┘
│ │
│ ▼
│ ┌─────────────────────┐
│ │ ValidatorFactory │
│ │ (abstract) │
│ ├─────────────────────┤
│ │ +CreateValidator() │
│ │ +ValidateMessage() │
│ └──────────┬──────────┘
│ │
▼ ▼
┌─────────────────┐ ┌─────────────────────┐
│ EmailValidator │ │ EmailValidatorFactory│
├─────────────────┤ ├─────────────────────┤
│ +Validate() │◄────────│ +CreateValidator() │
└─────────────────┘ └─────────────────────┘

┌─────────────────┐ ┌─────────────────────┐
│ PasswordValidator│ │PasswordValidatorFactory│
├─────────────────┤ ├─────────────────────┤
│ +Validate() │◄────────│ +CreateValidator() │
└─────────────────┘ └─────────────────────┘

┌─────────────────┐ ┌─────────────────────┐
│ PhoneValidator │ │ PhoneValidatorFactory│
├─────────────────┤ ├─────────────────────┤
│ +Validate() │◄────────│ +CreateValidator() │
└─────────────────┘ └─────────────────────┘
---

## Демонстрація роботи

### Вхідні дані
<img width="1452" height="952" alt="image" src="https://github.com/user-attachments/assets/2facaca0-f65b-45d8-a290-8ef8cff04246" />
<img width="901" height="663" alt="image" src="https://github.com/user-attachments/assets/e5d021f2-ca80-40b9-945a-f121bdbe202c" />
