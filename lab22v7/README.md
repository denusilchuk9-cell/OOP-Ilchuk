# Лабораторна 22: LSP принцип

## Початкове рішення (порушення LSP)
- Клас `User` з методом `ChangePassword()`
- Клас `GuestUser` успадковує від `User`
- `GuestUser` кидає виняток в `ChangePassword()`
- Це порушує LSP

## Виправлене рішення
- Інтерфейс `IUserInfo` для відображення інформації
- Інтерфейс `IPasswordChangeable` для зміни пароля
- `RegularUser` реалізує обидва інтерфейси
- `GuestAccount` реалізує тільки `IUserInfo`

## Запуск
```bash

dotnet run

скріншот виконання за посиланням 
https://github.com/denusilchuk9-cell/OOP-Ilchuk/issues/1 
