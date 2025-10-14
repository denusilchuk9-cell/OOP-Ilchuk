# Створюємо клас Figure
class Figure:
    # Конструктор — викликається при створенні об'єкта
    def __init__(self, name, area):
        self.__name = name         # приватне поле (дві нижні риски)
        self.area = area           # публічна властивість
        print("Figure created.")   # просто повідомлення

    # Деструктор — викликається при знищенні об'єкта
    def __del__(self):
        print("Figure destroyed.")

    # Метод — повертає інформацію про фігуру
    def get_figure(self):
        return f"Name: {self.__name}, Area: {self.area}"


# Створюємо об'єкти класу
f1 = Figure("Circle", 12.5)
f2 = Figure("Square", 20.0)

# Викликаємо метод і виводимо результат
print(f1.get_figure())
print(f2.get_figure())
def double_area(self):
    return self.__area * 2