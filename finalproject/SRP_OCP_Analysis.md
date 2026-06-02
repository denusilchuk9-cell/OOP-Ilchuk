1. Обраний проєкт

Назва: InventorySample

Посилання на GitHub: https://github.com/Microsoft/InventorySample

Проєкт InventorySample є відкритим прикладом застосунку на C#, розробленим компанією Microsoft. Він демонструє архітектурні підходи для бізнес-застосунків, зокрема використання патернів MVVM, сервісного шару та репозиторіїв, що робить його придатним для аналізу принципів SOLID.

2. Аналіз SRP (Single Responsibility Principle)
2.1. Приклади дотримання SRP
Клас: InventoryItem

Відповідальність: зберігання даних про одиницю товару

Обґрунтування: клас містить лише властивості, що описують стан об’єкта, і не містить бізнес-логіки або логіки доступу до даних

public class InventoryItem
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
}


Цей клас відповідає SRP, оскільки його єдина відповідальність — представлення моделі даних.

Клас: InventoryService

Відповідальність: робота з даними інвентарю

Обґрунтування: клас виконує лише операції, пов’язані з отриманням і обробкою товарів, не займаючись UI або збереженням даних

public class InventoryService
{
    public Task<IEnumerable<InventoryItem>> GetItemsAsync()
    {
        return Task.FromResult<IEnumerable<InventoryItem>>(new List<InventoryItem>());
    }
}


Клас має одну чітку зону відповідальності, що полегшує його підтримку та тестування.

Клас: InventoryViewModel

Відповідальність: підготовка даних для відображення у UI

Обґрунтування: ViewModel не містить логіки доступу до бази даних і не відповідає за бізнес-правила

public class InventoryViewModel
{
    public ObservableCollection<InventoryItem> Items { get; } 
        = new ObservableCollection<InventoryItem>();
}


Це відповідає SRP та принципам MVVM.

2.2. Приклади порушення SRP
Клас: MainPage

Множинні відповідальності:

логіка UI

обробка подій

ініціалізація даних

Проблеми: ускладнення тестування та підтримки, сильна зв’язаність з іншими компонентами

public sealed partial class MainPage : Page
{
    private void LoadData()
    {
        // логіка завантаження
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        LoadData();
    }
}


Клас виконує декілька різних ролей, що порушує SRP і може призвести до зростання складності коду.

3. Аналіз OCP (Open/Closed Principle)
3.1. Приклади дотримання OCP
Сценарій: використання інтерфейсу сервісу

Механізм розширення: інтерфейси та залежності

Обґрунтування: нові реалізації сервісу можна додати без зміни існуючого коду

public interface IInventoryService
{
    Task<IEnumerable<InventoryItem>> GetItemsAsync();
}

public class InventoryService : IInventoryService
{
    public Task<IEnumerable<InventoryItem>> GetItemsAsync()
    {
        return Task.FromResult<IEnumerable<InventoryItem>>(new List<InventoryItem>());
    }
}


Завдяки інтерфейсу можна легко створити альтернативну реалізацію сервісу.

Сценарій: MVVM-архітектура

Механізм розширення: ViewModel

Обґрунтування: нові ViewModel додаються без зміни існуючих View

public class BaseViewModel
{
    public bool IsBusy { get; set; }
}


Це дозволяє розширювати функціональність, не змінюючи вже реалізований код.

3.2. Приклади порушення OCP
Сценарій: умовна логіка у UI

Проблема: використання умовних операторів для вибору поведінки

Наслідки: для додавання нового сценарію потрібно змінювати існуючий код

if (item.Quantity == 0)
{
    ShowOutOfStock();
}
else
{
    ShowAvailable();
}


Для розширення логіки доведеться змінювати цей блок, що порушує OCP.

4. Загальні висновки

Проєкт InventorySample демонструє загалом якісний дизайн з використанням принципів SOLID. 
Принцип SRP добре дотримується на рівні моделей, сервісів та ViewModel, однак у UI-класах інколи спостерігаються порушення через поєднання кількох відповідальностей.
Принцип OCP реалізовано через використання інтерфейсів та архітектури MVVM, що дозволяє розширювати функціональність без модифікації існуючого коду. 
Загалом архітектура проєкту є гнучкою, зрозумілою та придатною для підтримки й масштабування.