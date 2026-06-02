Порушення LSP - приклади

1. Птахи (класичне порушення)


public class Bird {
    public virtual void Fly() { }  // ВСІ птахи літають?
}
public class Penguin : Bird {
    public override void Fly() {
        throw new Exception("Пінгвіни не літають!"); // ПРОБЛЕМА
    }
}
Проблема: Код, який очікує Bird і викликає Fly(), зламається для пінгвіна.
Виправлення: Розділити інтерфейси:

public interface IBird { }
public interface IFlyingBird { void Fly(); }
public class Penguin : IBird { }
public class Sparrow : IBird, IFlyingBird { }

2. Файловий процесор
   
public class FileWriter {
    public virtual void Write(string data) {
        // Записує дані
    }
}
public class ReadOnlyFileWriter : FileWriter {
    public override void Write(string data) {
        // НІЧОГО НЕ РОБИТЬ! Порушення LSP
    }
}
Проблема: Клієнт очікує запис, а отримує пусту операцію.
Виправлення: Використовувати окремі інтерфейси:

public interface IFileWriter { void Write(string data); }
public interface IFileReader { string Read(); }

3. Колекція з обмеженням


public class Collection {
    public virtual void Add(object item) { }
}
public class FixedSizeCollection : Collection {
    public override void Add(object item) {
        if (Count >= 10) 
            throw new Exception("Переповнено!"); // Порушення LSP
    }
}
Проблема: Базовий клас дозволяє додавати елементи без обмежень, похідний - ні.
Виправлення: Не успадковувати, а створити окремий клас:

public class FixedSizeCollection {
    private List<object> items = new List<object>();
    
    public bool TryAdd(object item) { 
        // Повертає true/false замість винятку
    }
}

Коротко про LSP:
Правило: Якщо клас B успадкований від A, то B має робити все те саме, що й A
Не можна: Викидати нові винятки, повертати null замість значення, слабшати умови
Можна: Робити більше, ніж батьківський клас, але не менше
