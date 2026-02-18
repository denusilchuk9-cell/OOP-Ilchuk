
## 1. Принцип розділення інтерфейсів (ISP)

**Порушення:** Інтерфейс IWorker містить 7 методів, через що клас Programmer змушений реалізовувати непотрібні методи Design(), Test(), Deploy() з викиданням винятків.

public interface IWorker { void Work(); void Eat(); void Sleep(); void Code(); void Design(); void Test(); void Deploy(); }
public class Programmer : IWorker { 
    public void Work() => Console.WriteLine("Working");
    public void Eat() => Console.WriteLine("Eating");
    public void Sleep() => Console.WriteLine("Sleeping");
    public void Code() => Console.WriteLine("Coding");
    public void Design() => throw new NotImplementedException();
    public void Test() => throw new NotImplementedException();
    public void Deploy() => throw new NotImplementedException();
}
Рішення: Розділяємо на вузькі інтерфейси IWorkable, IEatable, ISleepable, ICodeable, ITestable.

public interface IWorkable { void Work(); }
public interface IEatable { void Eat(); }
public interface ISleepable { void Sleep(); }
public interface ICodeable { void Code(); }
public interface ITestable { void Test(); }

public class Programmer : IWorkable, IEatable, ISleepable, ICodeable {
    public void Work() => Console.WriteLine("Working");
    public void Eat() => Console.WriteLine("Eating");
    public void Sleep() => Console.WriteLine("Sleeping");
    public void Code() => Console.WriteLine("Coding");
}
2. Принцип інверсії залежностей (DIP)
Застосування: Високорівневий модуль UserService залежить від абстракції ILogger, а не від конкретних класів.

public interface ILogger { void Log(string message); }
public class ConsoleLogger : ILogger { public void Log(string message) => Console.WriteLine($"LOG: {message}"); }
public class FileLogger : ILogger { public void Log(string message) => File.AppendAllText("log.txt", $"{message}\n"); }

public class UserService {
    private readonly ILogger _logger;
    public UserService(ILogger logger) { _logger = logger; }
    public void CreateUser(string name) { _logger.Log($"Creating user: {name}"); Console.WriteLine($"User {name} created!"); }
}
Переваги DIP: Гнучкість (легка заміна логера), тестованість (mock-об'єкти), слабке зв'язування.

3. Як ISP сприяє кращому DI та тестуванню
Вузькі інтерфейси дозволяють точно визначити залежності класу, що полегшує створення mock-об'єктів для тестування та дозволяє ін'єктувати лише необхідні компоненти.

public class ReportService {
    private readonly IDataReader _reader;
    private readonly IDataFormatter _formatter;
    public ReportService(IDataReader reader, IDataFormatter formatter) {
        _reader = reader;
        _formatter = formatter;
    }
}
Висновок: Поєднання ISP та DIP робить код гнучким, розширюваним та легким у тестуванні.
