Данное задание было специально подготовлено для прохождения перед посещением Мастер класса в рамках мероприятия Summer Bootcamp 2021.
Чтобы выполнить задание, следуйте приведённым ниже инструкциям:

### Скопируйте данный репозиторий в свой аккаунт
* Кликните **Fork** кнопку в правом верхнем углу данной страницы и репозиторий будет скопирован в ваш аккаунт.
* Выполните в консоли команду `git clone https://github.com/<your-account>/Summer_Bootcamp_2021.git`, где *your-account* - это имя вашего аккаунта в GitHub.

### Настройте рабочее окружение
* Скачайте и установите последнюю версию [Nodejs](https://nodejs.org/en/download/stable/).
* Выполните в консоли команду `npm install` из папки `JavaScript`. Все зависимости будут установлены в папку *node_modules*.
* Локальный репозиторий имеет следующую структуру: <pre>
    node_modules - все зависимости, установленные после выполнения команды `npm install`.
    task - папка с заданиями, в ней вы будете писать свой код.
    test - папка с тестами для проверки заданий.
</pre>

### Выполните задания
* Задания можно выполнять в любом текстовом редакторе.
* Каждый файл в папке **task** включает в себя несколько заданий по определённой теме. Каждое отдельное задание представляет собой отдельную функцию:
```javascript
  /**
   * Returns the result of concatenation of two strings.
   *
   * @param {string} value1
   * @param {string} value2
   * @return {string}
   *
   * @example
   *   'aa', 'bb' => 'aabb'
   *   'aa',''    => 'aa'
   *   '',  'bb'  => 'bb'
   */
  function concatenateStrings(value1, value2) {
     throw new Error('Not implemented');
  }
```
* Перед выполнением внимательно прочтите условие задания
* Удалите строку по выбросу ошибки из функции и напишите вместо неё свой код, чтобы функция выполняла поставленную в условии задачу.
```javascript
     throw new Error('Not implemented');
```
* После написания кода задания нужно проверить, чтобы удостовериться, что функции работают верно. Для этого выполните в консоли команду `npm run test`.
Данная команда выполнит **все** тесты на проверку **всех** заданий. Результаты будут отражены в консоли.
Для того, чтобы проверить задания отдельно (по темам), можно воспользоватьсы командами:
`npm run test:string` - работа со строками.
`npm run test:number` - работа с числами.
`npm run test:array` - работа с массивами.
`npm run test:loops` - циклы.
`npm run test:regex` - регулярные выражения.
* Как только вы будете видеть, что все тесты прошли, задание можно считать выполненным.