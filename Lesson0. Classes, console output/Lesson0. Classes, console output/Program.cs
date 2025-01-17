using Lesson0._Classes__console_output;

// task author's code
var tanks = GetTanks();
var units = GetUnits();
var factories = GetFactories();
Console.WriteLine($"Количество резервуаров: {tanks.Length}, установок: {units.Length}");

var foundUnit = FindUnit(units, tanks, "Резервуар 2");
var factory = FindFactory(factories, foundUnit);

Console.WriteLine($"Резервуар 2 принадлежит установке {foundUnit.Name} и заводу {factory.Name}");

var totalVolume = GetTotalVolume(tanks);
Console.WriteLine($"Общий объем резервуаров: {totalVolume}");

// end of task author's code

// tanks
static Tank[] GetTanks()
{
    Tank tank1 = new(1,"Резервуар 1", "Надземный - вертикальный", 1500, 2000, 1);
    Tank tank2 = new(2,"Резервуар 2", "Надземный - горизонтальный", 2500, 3000, 1);
    Tank additionalTank24 = new(3,"Дополнительный резервуар 24", "Надземный - горизонтальный", 3000, 3000, 2);
    Tank tank35 = new(4,"Резервуар 35", "Надземный - вертикальный", 3000, 3000, 2);
    Tank tank47 = new(5,"Резервуар 47", "Подземный - двустенный", 4000, 5000, 2);
    Tank tank256 = new(6,"Резервуар 256", "Подводный", 500, 500, 3);

    return [tank1, tank2, additionalTank24, tank35, tank47, tank256];
}
static int GetTotalVolume(Tank[] units)
{
    double totalVolume = 0;
    foreach(Tank tank in units)
    {
        totalVolume += tank.Volume;
    }
    return (int)totalVolume;
}

// end of tanks 

// units
static Unit[] GetUnits()
{
    Unit GFU_2 = new(1,"ГФУ-2", "Газофракционирующая установка", 1);
    Unit AVT_6 = new(2,"АВТ-6", "Атмосферно-вакуумная трубчатка", 1);
    Unit AVT_10 = new(3,"АВТ-10", "Атмосферно-вакуумная трубчатка", 2);

    return [GFU_2, AVT_10, AVT_6];
}
                                                                // автор задания немного не прав:
                                                                // я скопировал предложенную им
                                                                // сигнатуру метода и она кривая,
                                                                // потому что в действительности
                                                                // требуется найти unit по tankName,
                                                                // а не по unitName 
static Unit FindUnit(Unit[] units, Tank[] tanks, string unitName)
{
    int qIndex = -1;
    for(int i = 0; i < tanks.Length; i++)
    {
        if (tanks[i].Name == unitName)
        {
            qIndex = i;
            break;
        }
    }
    if (qIndex == -1)
    {
        Console.WriteLine("Резервуара с таким именем не найдено!");
        return null;
    }
    else
    {
        int uIndex = 0;
        int uId = tanks[qIndex].UnitId;
        for (int i = 0; i < units.Length; i++)
        {
            if (units[i].Id == uId)
            {
                uIndex = i;
                break;
            }
        }
        return units[uIndex];
    }
}

// end of units

// factories 
static Factory[] GetFactories()
{
    Factory NPZ_1 = new(1,"НПЗ№1", "Первый нефтеперерабатывающий завод");
    Factory NPZ_2 = new(2,"НПЗ№2", "Второй нефтеперерабатывающий завод");

    return [NPZ_1, NPZ_2];
}

static Factory FindFactory(Factory[] factories, Unit unit)
{
    int fId = unit.FactoryId;
    for (int i = 0; i < factories.Length; i++)
    {
        if (factories[i].Id == fId)
        {
            return factories[i];
        }
    }
    return null;
}
// end of factories