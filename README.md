# otus-lesson-30

## Написать вывод: какие преимущества и недостатки у каждого из интерфейсов: IMyCloneable и ICloneable.

IMyCloneable

Преимущества:
1. Работает с классами приложения
2. Через реализацию можно кастомизировать какая часть исходного класса будет клонироваться

Недостатки:

1. Требует трудозатрат на реализацию

ICloneable

Преимущества:
1. Встроенный интерфейс, прост в реализации
2. Есть удобные встроенные методы, например MemberwiseClone()

Недостатки:

1. Работает с типом object
2. Микрософт не рекомендует использовать, так как нет чёткости какое будет клонирование - глубокое или поверхностное
3. Вотт ссылка на статью
   https://learn.microsoft.com/ru-ru/archive/blogs/brada/should-we-obsolete-icloneable-the-slar-on-system-icloneable
