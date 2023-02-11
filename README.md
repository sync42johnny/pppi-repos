##1.	Які мови програмування підтримує CLR?
CLR – підтримує (С#, Managed C++, Visual Basic, NET, F#)
##2.	З яких компонентів складається CLR?
завантажувач класів, верифікатор, JIТ-компілятори та засоби підтримки виконання, такі як управління кодом, безпекою, складання сміття, управління винятками, налагодженням, маршалінгом, потоками
##3.	Скільки рівнів має Garbage Collector?
Існує три рівня об'єктів: нульове, перше та друге. До 0-го покоління належать нові об'єкти, які ще жодного разу не піддавалися збиранню сміття. До 1-го покоління відносяться об'єкти, які пережили одну збірку, а до 2-го покоління - об'єкти, що пройшли більше одного збирання сміття.
##4.	Коли викликається останній рівень GC?
Тригером для початку збирання сміття є досягнення поколінням порогового розміру. Коли загальний розмір об'єктів у 0-го покоління більше порогу, запуститься збирач сміття. Після запуску, GC дивиться, чи не перевищує сумарний розмір об'єктів у 2-го покоління поріг. Якщо перевищує, запускається повне, повільне збирання сміття всіх трьох поколінь.
##5.	Що таке CLS?
CLS - набір правил, що описують як мінімальний, так і повний набір функціональних можливостей, які повинен підтримувати кожен окремий .NET-компілятор.
