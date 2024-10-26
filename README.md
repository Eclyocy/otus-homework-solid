# SOLID

## Постановка задачи

### Цель

Практическое применение SOLID принципов.

### Описание

На примере реализации игры «Угадай число» продемонстрировать практическое применение SOLID принципов.

Программа рандомно генерирует число, пользователь должен угадать это число.<br/>
При каждом вводе числа программа пишет, больше ли оно или меньше отгадываемого.<br/>
Количество попыток отгадывания и диапазон чисел должен задаваться из настроек.

## Результаты

### Single Responsibility Principle (SRP)

Каждый класс имеет единственную, чётко определённую ответственность.

Например, [GeneratorService](GuessingGame/Services/GeneratorService.cs) отвечает исключительно за генерирование случайного числа в заданных пределах.

### Open/Closed Principle (OCP)

Код открыт для расширения, но закрыт для модификаций, благодаря использованию интерфейсов.

Например, предложенная реализация [IUserInteractionService](GuessingGame/Interfaces/IUserInteractionService.cs) использует взаимодействие через консоль. Можно заменить консоль на другой протокол в новой реализации интерфейса, не меняя сам интерфейс.

### Liskov Substitution Principle (LSP)


### Interface Segregation Principle (ISP)

Аналогично SRP, в каждый интерфейс выделена логика, специфичная для конкретной части программы.

### Dependency Inversion Principle (DIP)

Высокоуровневый модуль ([GameService](GuessingGame/Service/GameService.cs)) зависит от абстракций, а не от конкретики, благодаря DI.

<pre>
public GameService(
    IGeneratorService generatorService,
    IGuessCheckService guessCheckService,
    IUserInteractionService userInteractionService,
    IOptions<GameSettings> gameSettingsOptions)
{
    ...
}
</pre>
