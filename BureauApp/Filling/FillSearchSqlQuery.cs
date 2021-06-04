using System.Collections.Generic;
using System.Linq;
using BureauApp.SearchWindows;

namespace BureauApp
{
    class FillSearchSqlQuery
    {
        public static void FillHouseSearch(Query query, HouseSearch houseSearch)
        {
            query.Sql = "SELECT * FROM houses WHERE ";

            List<FieldAndValue> textFields = new List<FieldAndValue>();
            FieldAndValue kdstr = new FieldAndValue("Kadastr", houseSearch.kadastr.Text);
            FieldAndValue ct = new FieldAndValue("CityName", houseSearch.city.Text);
            FieldAndValue dstrct = new FieldAndValue("DistrictName", houseSearch.district.Text);
            FieldAndValue strt = new FieldAndValue("Street", houseSearch.street.Text);
            FieldAndValue bs = new FieldAndValue("BaseType", houseSearch.@base.Text);
            FieldAndValue mtrl = new FieldAndValue("MaterialType", houseSearch.material.Text);

            textFields.Add(kdstr);
            textFields.Add(ct);
            textFields.Add(dstrct);
            textFields.Add(strt);
            textFields.Add(bs);
            textFields.Add(mtrl);


            bool textEmpty = true;
            int index = 0;

            for (int i = 0; i < textFields.Count; i++)
            {
                if (textFields[i].Value != string.Empty)
                {
                    textEmpty = false;
                    index = i;
                }
                if (!textEmpty) break;
            }

            if (!textEmpty)
            {
                for (int i = index; i < textFields.Count; i++)
                {
                    if (i == index)
                    {
                        query.Sql += textFields[i].Field_name + "='" + textFields[i].Value + "' ";
                    }
                    else
                    {
                        if (textFields[i].Value != string.Empty)
                        {
                            query.Sql += "AND " + textFields[i].Field_name + "='" + textFields[i].Value + "' ";
                        }
                    }
                }
            }

            List<NumFieldAndValue> numFields = new List<NumFieldAndValue>();
            NumFieldAndValue hs_nmbr = new NumFieldAndValue("House_number", houseSearch.house_number_low.Text, houseSearch.house_number_high.Text);
            NumFieldAndValue ln = new NumFieldAndValue("Line", houseSearch.line_low.Text, houseSearch.line_high.Text);
            NumFieldAndValue yr = new NumFieldAndValue("Year", houseSearch.year_low.Text, houseSearch.year_high.Text);
            NumFieldAndValue wr = new NumFieldAndValue("Wear", houseSearch.wear_low.Text, houseSearch.wear_high.Text);
            NumFieldAndValue lnd = new NumFieldAndValue("Land", houseSearch.land_low.Text, houseSearch.land_high.Text);
            NumFieldAndValue sqr = new NumFieldAndValue("Square", houseSearch.square_low.Text, houseSearch.square_high.Text);
            NumFieldAndValue flw = new NumFieldAndValue("Flow", houseSearch.flow_low.Text, houseSearch.flow_high.Text);
            NumFieldAndValue hll = new NumFieldAndValue("Hall", houseSearch.hall_low.Text, houseSearch.hall_high.Text);

            numFields.Add(hs_nmbr);
            numFields.Add(ln);
            numFields.Add(yr);
            numFields.Add(wr);
            numFields.Add(lnd);
            numFields.Add(sqr);
            numFields.Add(flw);
            numFields.Add(hll);

            if (!textEmpty)
            {
                foreach (NumFieldAndValue field in numFields)
                {
                    query.Sql += "AND " + field.Field_name + " BETWEEN '" + (field.Lower_value).ToString().Replace(',','.') + "' AND '" + (field.Higher_value).ToString().Replace(',', '.') + "' ";
                }
            }
            else
            {
                query.Sql += numFields[0].Field_name + " BETWEEN '" + numFields[0].Lower_value + "' AND '" + numFields[0].Higher_value + "' ";
                for (int i = 1; i < numFields.Count(); i++)
                {
                    query.Sql += " AND " + (numFields[i].Field_name).ToString().Replace(',', '.') + " BETWEEN '" + numFields[i].Lower_value + "' AND '" + (numFields[i].Higher_value).ToString().Replace(',', '.') + "' ";
                }
            }

            if (houseSearch.elevator_true.IsChecked == true && houseSearch.elevator_false.IsChecked == true) { }
            else
            {
                if(houseSearch.elevator_true.IsChecked == true)
                query.Sql += " AND Elevator='1'";
                if (houseSearch.elevator_false.IsChecked == true)
                    query.Sql += " AND Elevator='0'";
            }

        }
        public static void FillFlatSearch(Query query, FlatSearch flatSearch)
        {
            query.Sql = "SELECT * FROM flats WHERE ";

            FieldAndValue kdstr = new FieldAndValue("Kadastr", flatSearch.kadastr.Text);

            bool textEmpty = true;

            if (kdstr.Value != string.Empty) textEmpty = false;

            if (!textEmpty)
            {
                query.Sql += kdstr.Field_name + "='" + kdstr.Value + "' ";
            }

            List<NumFieldAndValue> numFields = new List<NumFieldAndValue>();
            NumFieldAndValue fl_nmbr = new NumFieldAndValue("Flat_number", flatSearch.flat_number_low.Text, flatSearch.flat_number_high.Text);
            NumFieldAndValue str = new NumFieldAndValue("Storey", flatSearch.storey_low.Text, flatSearch.storey_high.Text);
            NumFieldAndValue rms = new NumFieldAndValue("Rooms", flatSearch.rooms_low.Text, flatSearch.rooms_high.Text);
            NumFieldAndValue hght = new NumFieldAndValue("Height", flatSearch.height_low.Text, flatSearch.height_high.Text);
            NumFieldAndValue sqrhl = new NumFieldAndValue("SquareHall", flatSearch.square_hall_low.Text, flatSearch.square_hall_high.Text);
            NumFieldAndValue lvsqr = new NumFieldAndValue("LivingSquare", flatSearch.living_square_low.Text, flatSearch.living_square_high.Text);
            NumFieldAndValue br = new NumFieldAndValue("Branch", flatSearch.branch_low.Text, flatSearch.branch_high.Text);
            NumFieldAndValue bl = new NumFieldAndValue("Balcony", flatSearch.balcony_low.Text, flatSearch.balcony_high.Text);


            numFields.Add(fl_nmbr);
            numFields.Add(str);
            numFields.Add(rms);
            numFields.Add(hght);
            numFields.Add(sqrhl);
            numFields.Add(lvsqr);
            numFields.Add(br);
            numFields.Add(bl);

            if (!textEmpty)
            {
                foreach (NumFieldAndValue field in numFields)
                {
                    query.Sql += "AND " + field.Field_name + " BETWEEN '" + (field.Lower_value).ToString().Replace(',', '.') + "' AND '" + (field.Higher_value).ToString().Replace(',', '.') + "' ";
                }
            }
            else
            {
                query.Sql += numFields[0].Field_name + " BETWEEN '" + (numFields[0].Lower_value).ToString().Replace(',', '.') + "' AND '" + (numFields[0].Higher_value).ToString().Replace(',', '.') + "' ";
                for (int i = 1; i < numFields.Count(); i++)
                {
                    query.Sql += " AND " + numFields[i].Field_name + " BETWEEN '" + (numFields[i].Lower_value).ToString().Replace(',', '.') + "' AND '" + (numFields[i].Higher_value).ToString().Replace(',', '.') + "' ";
                }
            }

            if (flatSearch.level_true.IsChecked == true && flatSearch.level_false.IsChecked == true) { }
            else
            {
                if (flatSearch.level_true.IsChecked == true)
                    query.Sql += " AND Level='1'";
                if (flatSearch.level_false.IsChecked == true)
                    query.Sql += " AND Level='0'";
            }

        }
        public static void FillRoomSearch(Query query, RoomSearch roomSearch)
        {
            query.Sql = "SELECT * FROM rooms WHERE ";

            List<FieldAndValue> textFields = new List<FieldAndValue>();
            FieldAndValue kdstr = new FieldAndValue("FK_Kadastr", roomSearch.kadastr.Text);
            FieldAndValue npn = new FieldAndValue("NamePartName", roomSearch.name_part_name.Text);
            FieldAndValue wdt = new FieldAndValue("WallDecorationType", roomSearch.wall.Text);
            FieldAndValue fdt = new FieldAndValue("FloorDecorationType", roomSearch.floor.Text);
            FieldAndValue cdt = new FieldAndValue("CeilingDecorationType", roomSearch.ceiling.Text);

            textFields.Add(kdstr);
            textFields.Add(npn);
            textFields.Add(wdt);
            textFields.Add(fdt);
            textFields.Add(cdt);

            bool textEmpty = true;
            int index=0;

            for (int i=0; i<textFields.Count; i++)
            {
                if (textFields[i].Value != string.Empty)
                {
                    textEmpty = false;
                    index = i;
                }
                if (!textEmpty) break;
            }
            
            if (!textEmpty)
            {
                for (int i=index; i< textFields.Count; i++)
                {
                    if (i == index)
                    {
                        query.Sql += textFields[i].Field_name + "='" + textFields[i].Value + "' ";
                    }
                    else
                    {
                        if (textFields[i].Value != string.Empty)
                        {
                            query.Sql += "AND " + textFields[i].Field_name + "='" + textFields[i].Value + "' ";
                        }
                    }
                }
            }

            List<NumFieldAndValue> numFields = new List<NumFieldAndValue>();
            NumFieldAndValue fl_nmbr = new NumFieldAndValue("Flat_number", roomSearch.flat_number_low.Text, roomSearch.flat_number_high.Text);
            NumFieldAndValue rcrd = new NumFieldAndValue("Record", roomSearch.record_low.Text, roomSearch.record_high.Text);
            NumFieldAndValue sck = new NumFieldAndValue("Socket", roomSearch.socket_low.Text, roomSearch.socket_high.Text);
            NumFieldAndValue sec = new NumFieldAndValue("Sections", roomSearch.section_low.Text, roomSearch.section_high.Text);
            NumFieldAndValue sqr = new NumFieldAndValue("SquarePart", roomSearch.square_part_low.Text, roomSearch.square_part_high.Text);
            NumFieldAndValue lnght = new NumFieldAndValue("Length", roomSearch.lenght_low.Text, roomSearch.lenght_high.Text);
            NumFieldAndValue wdth = new NumFieldAndValue("Width", roomSearch.width_low.Text, roomSearch.width_high.Text);
            NumFieldAndValue hght = new NumFieldAndValue("HeightPart", roomSearch.height_low.Text, roomSearch.height_high.Text);

            numFields.Add(fl_nmbr);
            numFields.Add(rcrd);
            numFields.Add(sck);
            numFields.Add(sec);
            numFields.Add(sqr);
            numFields.Add(wdth);
            numFields.Add(lnght);
            numFields.Add(hght);

            if (!textEmpty)
            {
                foreach (NumFieldAndValue field in numFields)
                {
                    query.Sql += "AND " + field.Field_name + " BETWEEN '" + (field.Lower_value).ToString().Replace(',', '.') + "' AND '" + (field.Higher_value).ToString().Replace(',', '.') + "' ";
                }
            }
            else
            {
                query.Sql += numFields[0].Field_name + " BETWEEN '" + (numFields[0].Lower_value).ToString().Replace(',', '.') + "' AND '" + (numFields[0].Higher_value).ToString().Replace(',', '.') + "' ";
                for (int i = 1; i < numFields.Count(); i++)
                {
                    query.Sql += " AND " + numFields[i].Field_name + " BETWEEN '" + (numFields[i].Lower_value).ToString().Replace(',', '.') + "' AND '" + (numFields[i].Higher_value).ToString().Replace(',', '.') + "' ";
                }
            }

        }

    }
}
