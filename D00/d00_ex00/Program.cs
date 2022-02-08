using static System.Math;

double sum;
double rate;
int term;

/*Считываем данные с консоли, завершаем работу приложения с ошибкой, если что-то пошло не так*/

try
{
    Console.WriteLine("Введите сумма кредита");
    sum = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Введите процентную ставку");
    rate = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Введите кол-во месяцев кредита");
    term = Convert.ToInt32(Console.ReadLine());
    if (term < 0 || rate < 0 || sum < 0)
        throw new Exception();
}
catch
{ 
    Console.WriteLine("Something went wrong.Check your input and retry.");
    return;
}
CreditCalculator(sum, rate, term);

/*Высчитываем общий ежемесячный платёж*/

double CalcSumMonthPayment(double newSum, double newI, int NewTerm)
{
    return ((newSum * newI * Pow(1 + newI, NewTerm))
        /(Pow(1+newI,NewTerm) - 1));
}

/*Высчитываем процентную ставку по займу в месяц*/

double CalcI(double newRate)
{
    return (newRate / 12 / 100);
}

/*Высчитываем проценты ежемесячного платежа*/

double CalcPercent(double newSum, double newRate, int newDaysOfMonth, int newDaysOfYear)
{
    return ((newSum * newRate * (newDaysOfMonth)) / (100 * newDaysOfYear));
}

/*Если при округлении до 2х знаков после запятой остаётся один знак добавляем нолик*/

string PrintNumber(double newNumber)
{
    string[] str = Round(newNumber,2).ToString().Split(',');
    if (str[1].Length < 2)
        return (Round(newNumber,2).ToString() + "0");
    else
        return (Round(newNumber,2).ToString());
}

/*Кредитный калькулятор*/

void CreditCalculator(double newSum, double newRate, int NewTerm)
{
    double _sum = newSum;
    double _rate = newRate;
    int _term = term;
    DateTime date = new DateTime(2021, 5, 1);
    int j = 0;
    double _i = CalcI(newRate);
    double _monthPayment = CalcSumMonthPayment(_sum, _i, _term);
    while (j < _term)
    {
        int _dayInMonth = DateTime.DaysInMonth(date.Year, date.Month);
        int _dayInYear = DateTime.IsLeapYear(date.Year) ? 366 : 365;
        date = date.AddMonths(1);
        double _percent = CalcPercent(_sum, _rate, _dayInMonth, _dayInYear);

        if (j < _term - 1)
            Console.WriteLine($"{j + 1}\t\t{date.Month}/{date.Day}/{date.Year}\t\t" +
                $"{PrintNumber(_monthPayment)}\t\t{PrintNumber(_monthPayment - _percent)}\t\t" +
                $"{PrintNumber(_percent)}\t\t{PrintNumber(_sum - (_monthPayment - _percent))}");
        else
            Console.WriteLine($"{j + 1}\t\t{date.Month}/{date.Day}/{date.Year}\t\t" +
                $"{PrintNumber(_sum + _percent)}\t\t{PrintNumber(_monthPayment)}\t\t" +
                $"{PrintNumber(_percent)}\t\t{0}");
        j++;
        _sum = _sum - (_monthPayment - _percent);
    }
}
