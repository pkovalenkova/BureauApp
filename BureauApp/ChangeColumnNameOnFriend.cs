using MySql.Data.MySqlClient;
using System.Data.Common;

namespace BureauApp
{
    class ChangeColumnNameOnFriend
    {
        static public void Change(MySqlDataAdapter adapter, string tableName)
        {
            DataTableMapping tableMapping;
            switch (tableName)
            {
                case "houses":
                    tableMapping = adapter.TableMappings.Add("houses", "Здания");
                    tableMapping.ColumnMappings.Add("Kadastr", "Кадастр");
                    tableMapping.ColumnMappings.Add("CityName", "Город");
                    tableMapping.ColumnMappings.Add("Street", "Улица");
                    tableMapping.ColumnMappings.Add("House_number", "Номер дома");
                    tableMapping.ColumnMappings.Add("DistrictName", "Район");
                    tableMapping.ColumnMappings.Add("Land", "Площадь земельного участка");
                    tableMapping.ColumnMappings.Add("Year", "Год постройки");
                    tableMapping.ColumnMappings.Add("MaterialType", "Материал стен");
                    tableMapping.ColumnMappings.Add("BaseType", "Материал фундамента");
                    tableMapping.ColumnMappings.Add("Wear", "Износ");
                    tableMapping.ColumnMappings.Add("Comment", "Комментарий");
                    tableMapping.ColumnMappings.Add("Flow", "Количество этажей");
                    tableMapping.ColumnMappings.Add("Line", "Расстояние до центра города");
                    tableMapping.ColumnMappings.Add("Square", "Площадь квартир");
                    tableMapping.ColumnMappings.Add("Hall", "Количество квартир в здании");
                    tableMapping.ColumnMappings.Add("Elevator", "Наличие лифта");
                    break;
                case "flats":
                    tableMapping = adapter.TableMappings.Add("flats", "Квартиры");
                    tableMapping.ColumnMappings.Add("FK_Kadastr", "Кадастр");
                    tableMapping.ColumnMappings.Add("Flat_ID", "Код квартиры");
                    tableMapping.ColumnMappings.Add("Flat_number", "Номер квартиры");
                    tableMapping.ColumnMappings.Add("Storey", "Этаж");
                    tableMapping.ColumnMappings.Add("Rooms", "Количество комнат");
                    tableMapping.ColumnMappings.Add("Level", "Двухуровневая");
                    tableMapping.ColumnMappings.Add("SquareHall", "Общая площадь");
                    tableMapping.ColumnMappings.Add("LivingSquare", "Жилая площадь");
                    tableMapping.ColumnMappings.Add("Branch", "Всп площадь");
                    tableMapping.ColumnMappings.Add("Balcony", "Площадь балкона");
                    tableMapping.ColumnMappings.Add("Height", "Высота потолков");
                    break;
                case "rooms":
                    tableMapping = adapter.TableMappings.Add("rooms", "Комнаты");
                    tableMapping.ColumnMappings.Add("FK_Kadastr", "Кадастр");
                    tableMapping.ColumnMappings.Add("FK_FLAT_ID", "Кадастр");
                    tableMapping.ColumnMappings.Add("Flat_number", "Номер квартиры");
                    tableMapping.ColumnMappings.Add("Room_ID", "Код комнаты");
                    tableMapping.ColumnMappings.Add("Record", "Номер помещения на плане");
                    tableMapping.ColumnMappings.Add("NamePartName", "Назначение");
                    tableMapping.ColumnMappings.Add("SquarePart", "Площадь помещения");
                    tableMapping.ColumnMappings.Add("Length", "Длина");
                    tableMapping.ColumnMappings.Add("Width", "Ширина");
                    tableMapping.ColumnMappings.Add("WallDecorationType", "Отделка стен");
                    tableMapping.ColumnMappings.Add("FloorDecorationType", "Отделка пола");
                    tableMapping.ColumnMappings.Add("CeilingDecorationType", "Отделка потолка");
                    tableMapping.ColumnMappings.Add("HeightPart", "Высота помещения");
                    tableMapping.ColumnMappings.Add("Socket", "Число розеток");
                    tableMapping.ColumnMappings.Add("Sections", "Число элементов в батарее отопления");
                    break;
                case "users":
                    tableMapping = adapter.TableMappings.Add("users", "Пользователи");
                    tableMapping.ColumnMappings.Add("User_ID", "Код пользователя");
                    tableMapping.ColumnMappings.Add("Login", "Логин");
                    tableMapping.ColumnMappings.Add("Password", "Пароль");
                    tableMapping.ColumnMappings.Add("Role", "Уровень учетной записи");
                    break;
            }

        }
    }
}
