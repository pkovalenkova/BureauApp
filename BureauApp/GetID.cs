using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BureauApp
{
    class GetID
    {
        public static int GetCityID(Query query, string city)
        {
            int city_ID;
            query.Sql = $"SELECT COUNT(1) FROM city_r WHERE CityName='{city}'";
            MySqlCommand cmd_CheckCity = new MySqlCommand(query.Sql, query.Conn);
            cmd_CheckCity.ExecuteScalar();
            Convert.ToInt32(cmd_CheckCity.ExecuteScalar());
            int countCity = new Int32();
            countCity = Convert.ToInt32(cmd_CheckCity.ExecuteScalar());

            if (countCity == 0)
            {
                query.Sql = $"INSERT INTO city_r (CityName) VALUES('{city}')";
                MySqlCommand cmd_AddNewCity = new MySqlCommand(query.Sql, query.Conn);
                cmd_AddNewCity.ExecuteNonQuery();
            }

            query.Sql = $"SELECT City_ID FROM city_r WHERE CityName='{city}'";
            MySqlCommand cmd_GetCityID = new MySqlCommand(query.Sql, query.Conn);
            city_ID = Convert.ToInt32(cmd_GetCityID.ExecuteScalar());

            return city_ID;
        }
        public static int GetDistrictID(Query query, string district)
        {
            int district_ID;
            query.Sql = $"SELECT COUNT(1) FROM district_r WHERE DistrictName='{district}'";
            MySqlCommand cmd_CheckDistrict = new MySqlCommand(query.Sql, query.Conn);
            int countDistrict = Convert.ToInt32(cmd_CheckDistrict.ExecuteScalar());

            if (countDistrict == 0)
            {
                query.Sql = $"INSERT INTO district_r (DistrictName) VALUES('{district}')";
                MySqlCommand cmd_AddNewDistrict = new MySqlCommand(query.Sql, query.Conn);
                cmd_AddNewDistrict.ExecuteNonQuery();
            }

            query.Sql = $"SELECT District_ID FROM district_r WHERE DistrictName='{district}'";
            MySqlCommand cmd_GetDistrictID = new MySqlCommand(query.Sql, query.Conn);
            district_ID = Convert.ToInt32(cmd_GetDistrictID.ExecuteScalar());

            return district_ID;
        }
        public static int GetMaterialID(Query query, string material)
        {
            int material_ID;
            query.Sql = $"SELECT COUNT(1) FROM wallmaterial_r WHERE MaterialType='{material}'";
            MySqlCommand cmd_CheckMaterial = new MySqlCommand(query.Sql, query.Conn);
            int countMaterial = Convert.ToInt32(cmd_CheckMaterial.ExecuteScalar());

            if (countMaterial == 0)
            {
                query.Sql = $"INSERT INTO wallmaterial_r (MaterialType) VALUES('{material}')";
                MySqlCommand cmd_AddNewMaterial = new MySqlCommand(query.Sql, query.Conn);
                cmd_AddNewMaterial.ExecuteNonQuery();
            }

            query.Sql = $"SELECT Material_ID FROM wallmaterial_r WHERE MaterialType='{material}'";
            MySqlCommand cmd_GetMaterialID = new MySqlCommand(query.Sql, query.Conn);
            material_ID = Convert.ToInt32(cmd_GetMaterialID.ExecuteScalar());

            return material_ID;
        }
        public static int GetBaseID(Query query, string @base)
        {
            int base_ID;
            query.Sql = $"SELECT COUNT(1) FROM basematerial_r WHERE BaseType='{@base}'";
            MySqlCommand cmd_CheckBase = new MySqlCommand(query.Sql, query.Conn);
            int countBase = Convert.ToInt32(cmd_CheckBase.ExecuteScalar());

            if (countBase == 0)
            {
                query.Sql = $"INSERT INTO basematerial_r (BaseType) VALUES('{@base}')";
                MySqlCommand cmd_AddNewBase = new MySqlCommand(query.Sql, query.Conn);
                cmd_AddNewBase.ExecuteNonQuery();
            }

            query.Sql = $"SELECT Base_ID FROM basematerial_r WHERE BaseType='{@base}'";
            MySqlCommand cmd_GetBaseID = new MySqlCommand(query.Sql, query.Conn);
            base_ID = Convert.ToInt32(cmd_GetBaseID.ExecuteScalar());

            return base_ID;
        }
        public static int GetNamePartID(Query query, string name_part_name)
        {
            int name_part_ID;
            query.Sql = $"SELECT COUNT(1) FROM namepart_r WHERE NamePartName='{name_part_name}'";
            MySqlCommand cmd_NamePart = new MySqlCommand(query.Sql, query.Conn);
            int countNamePart = Convert.ToInt32(cmd_NamePart.ExecuteScalar());

            if (countNamePart == 0)
            {
                query.Sql = $"INSERT INTO namepart_r (NamePartName) VALUES('{name_part_name}')";
                MySqlCommand cmd_AddNewNamePart = new MySqlCommand(query.Sql, query.Conn);
                cmd_AddNewNamePart.ExecuteNonQuery();
            }

            query.Sql = $"SELECT NamePart_ID FROM namepart_r WHERE NamePartName='{name_part_name}'";
            MySqlCommand cmd_NamePartID = new MySqlCommand(query.Sql, query.Conn);
            name_part_ID = Convert.ToInt32(cmd_NamePartID.ExecuteScalar());

            return name_part_ID;
        }
        public static int GetWallDecorationID(Query query, string wall)
        {
            int walldecoration_ID;
            query.Sql = $"SELECT COUNT(1) FROM walldecoration_r WHERE WallDecorationType='{wall}'";
            MySqlCommand cmd_WallDecoration = new MySqlCommand(query.Sql, query.Conn);
            int countWallDecoration = Convert.ToInt32(cmd_WallDecoration.ExecuteScalar());

            if (countWallDecoration == 0)
            {
                query.Sql = $"INSERT INTO walldecoration_r (WallDecorationType) VALUES('{wall}')";
                MySqlCommand cmd_AddNewWallDecoration = new MySqlCommand(query.Sql, query.Conn);
                cmd_AddNewWallDecoration.ExecuteNonQuery();
            }

            query.Sql = $"SELECT WallDecoration_ID FROM walldecoration_r WHERE WallDecorationType='{wall}'";
            MySqlCommand cmd_WallDecorationID = new MySqlCommand(query.Sql, query.Conn);
            walldecoration_ID = Convert.ToInt32(cmd_WallDecorationID.ExecuteScalar());

            return walldecoration_ID;
        }
        public static int GetFloorDecorationID(Query query, string floor)
        {
            int floordecoration_ID;
            query.Sql = $"SELECT COUNT(1) FROM floordecoration_r WHERE FloorDecorationType='{floor}'";
            MySqlCommand cmd_FloorDecoration = new MySqlCommand(query.Sql, query.Conn);
            int countFloorDecoration = Convert.ToInt32(cmd_FloorDecoration.ExecuteScalar());

            if (countFloorDecoration == 0)
            {
                query.Sql = $"INSERT INTO floordecoration_r (FloorDecorationType) VALUES ('{floor}')";
                MySqlCommand cmd_AddNewFloorDecoration = new MySqlCommand(query.Sql, query.Conn);
                cmd_AddNewFloorDecoration.ExecuteNonQuery();
            }

            query.Sql = $"SELECT FloorDecoration_ID FROM floordecoration_r WHERE FloorDecorationType='{floor}'";
            MySqlCommand cmd_FloorDecorationID = new MySqlCommand(query.Sql, query.Conn);
            floordecoration_ID = Convert.ToInt32(cmd_FloorDecorationID.ExecuteScalar());

            return floordecoration_ID;
        }
        public static int GetCeilingDecorationID(Query query, string ceiling)
        {
            int ceilingdecoration_ID;
            query.Sql = $"SELECT COUNT(1) FROM ceilingdecoration_r WHERE CeilingDecorationType='{ceiling}'";
            MySqlCommand cmd_CeilingDecoration = new MySqlCommand(query.Sql, query.Conn);
            int countCeilingDecoration = Convert.ToInt32(cmd_CeilingDecoration.ExecuteScalar());

            if (countCeilingDecoration == 0)
            {
                query.Sql = $"INSERT INTO ceilingdecoration_r (CeilingDecorationType) VALUES('{ceiling}')";
                MySqlCommand cmd_AddNewCeilingDecoration = new MySqlCommand(query.Sql, query.Conn);
                cmd_AddNewCeilingDecoration.ExecuteNonQuery();
            }

            query.Sql = $"SELECT CeilingDecoration_ID FROM ceilingdecoration_r WHERE CeilingDecorationType='{ceiling}'";
            MySqlCommand cmd_CeilingDecorationID = new MySqlCommand(query.Sql, query.Conn);
            ceilingdecoration_ID = Convert.ToInt32(cmd_CeilingDecorationID.ExecuteScalar());

            return ceilingdecoration_ID;
        }
        public static int GetFlatID(Query query, string kadastr, string flat_number)
        {
            query.Sql = $"SELECT Flat_ID FROM flat WHERE FK_Kadastr='{kadastr}' AND Flat_number='{flat_number}'";
            MySqlCommand cmd_GetFlatID = new MySqlCommand(query.Sql, query.Conn);
            int Flat_ID = Convert.ToInt32(cmd_GetFlatID.ExecuteScalar());
            return Flat_ID;
        }
    }
}
