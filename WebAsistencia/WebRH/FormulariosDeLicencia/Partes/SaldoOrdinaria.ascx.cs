#region

using System;
using System.Web.UI.WebControls;
using WSViaticos;
using System.Collections.Generic;

#endregion

public partial class FormulariosDeLicencia_Partes_SaldoOrdinaria : System.Web.UI.UserControl
{
    private int _DiasDisponibles;
    public int DiasDisponibles
    {
        get { return _DiasDisponibles; }
        set { _DiasDisponibles = value; }
    }

    private int _DiasSolicitados;
    public int DiasSolicitados
    {
        get { return _DiasSolicitados; }
        set
        {
            _DiasSolicitados = value;
            this.LSolicitadas.Text = value.ToString() + " Días";
        }
    }

    private ConceptoDeLicencia _Concepto;

    public ConceptoDeLicencia Concepto
    {
        get { return _Concepto; }
        set { _Concepto = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            WSViaticosSoapClient s = new WSViaticosSoapClient();
            //WSViaticos.WSViaticos s = new WSViaticos.WSViaticos();

            List<Persona> personas_list = GetEmpleadosExcelFaby(); //GetEmpleadosExcelFabyDotacionParcial(); // //GetSerra(); //
            SaldoLicencia saldo;
            personas_list.ForEach(p =>
            {
                saldo = s.GetSaldoLicencia(p, this.Concepto);
                s.GuardarSaldoLicencia(saldo, p);
                // s.GuardarSaldoLicenciaLAN(p);

            });


        }
        else
        {
            SaldoLicencia saldo = (SaldoLicencia)Session["saldoLicencia"];
            foreach (SaldoLicenciaDetalle d in saldo.Detalle)
            {
                InsertarDetalleDeSaldo(d);
            }
        }
    }

    private void InsertarDetalleDeSaldo(SaldoLicenciaDetalle detalle)
    {
        TableRow tr = new TableRow();
        TableCell tc = new TableCell();
        string[] fuentes = { "Tahoma" };
        tc.Text = "&nbsp;&nbsp;&nbsp;&nbsp;Periodo " + detalle.Periodo.ToString() + ": ";
        tc.Font.Size = FontUnit.Small;
        tc.Font.Names = fuentes;
        tr.Cells.Add(tc);

        tc = new TableCell();
        tc.Text = detalle.Disponible.ToString() + " Días";
        this.DiasDisponibles += detalle.Disponible;
        tc.Font.Size = FontUnit.Small;
        tc.Font.Names = fuentes;
        tr.Cells.Add(tc);
        this.TDiasDisponibles.Rows.Add(tr);
    }

    private List<Persona> GetCasoRaro()
    {
        List<Persona> personas_list = new List<Persona>();
        var persona0 = new Persona(); persona0.Documento = 5268053; personas_list.Add(persona0);
        return personas_list;
    }



    private List<Persona> GetDosCasos()
    {
        List<Persona> personas_list = new List<Persona>();
        var persona130 = new Persona(); persona130.Documento = 13687754; personas_list.Add(persona130);
        var persona187 = new Persona(); persona187.Documento = 4514173; personas_list.Add(persona187);
        return personas_list;
    }

    private List<Persona> GetEmpleadosExcelFabyDotacionParcial()
    {
        List<Persona> personas_list = new List<Persona>();
        var persona1 = new Persona(); persona1.Documento = 30496067; personas_list.Add(persona1);
        var persona2 = new Persona(); persona2.Documento = 20314615; personas_list.Add(persona2);
        var persona3 = new Persona(); persona3.Documento = 29668810; personas_list.Add(persona3);
        var persona4 = new Persona(); persona4.Documento = 28647060; personas_list.Add(persona4);
        var persona5 = new Persona(); persona5.Documento = 25355385; personas_list.Add(persona5);
        var persona6 = new Persona(); persona6.Documento = 23817341; personas_list.Add(persona6);
        var persona7 = new Persona(); persona7.Documento = 13801496; personas_list.Add(persona7);
        var persona8 = new Persona(); persona8.Documento = 28280902; personas_list.Add(persona8);
        var persona9 = new Persona(); persona9.Documento = 32552357; personas_list.Add(persona9);
        var persona10 = new Persona(); persona10.Documento = 34353508; personas_list.Add(persona10);
        var persona11 = new Persona(); persona11.Documento = 30276765; personas_list.Add(persona11);
        var persona12 = new Persona(); persona12.Documento = 21412573; personas_list.Add(persona12);
        var persona13 = new Persona(); persona13.Documento = 30025206; personas_list.Add(persona13);
        var persona14 = new Persona(); persona14.Documento = 18408015; personas_list.Add(persona14);
        var persona15 = new Persona(); persona15.Documento = 21115195; personas_list.Add(persona15);
        var persona16 = new Persona(); persona16.Documento = 25879581; personas_list.Add(persona16);
        var persona17 = new Persona(); persona17.Documento = 13490268; personas_list.Add(persona17);
        var persona18 = new Persona(); persona18.Documento = 31779295; personas_list.Add(persona18);
        var persona19 = new Persona(); persona19.Documento = 24054053; personas_list.Add(persona19);
        var persona20 = new Persona(); persona20.Documento = 31064157; personas_list.Add(persona20);
        var persona21 = new Persona(); persona21.Documento = 8464872; personas_list.Add(persona21);
        var persona22 = new Persona(); persona22.Documento = 26420637; personas_list.Add(persona22);
        var persona23 = new Persona(); persona23.Documento = 21430866; personas_list.Add(persona23);
        var persona24 = new Persona(); persona24.Documento = 27666988; personas_list.Add(persona24);
        var persona25 = new Persona(); persona25.Documento = 10108434; personas_list.Add(persona25);
        var persona26 = new Persona(); persona26.Documento = 27182589; personas_list.Add(persona26);
        var persona27 = new Persona(); persona27.Documento = 23910920; personas_list.Add(persona27);
        var persona28 = new Persona(); persona28.Documento = 28087629; personas_list.Add(persona28);
        var persona29 = new Persona(); persona29.Documento = 32523600; personas_list.Add(persona29);
        var persona30 = new Persona(); persona30.Documento = 33895264; personas_list.Add(persona30);
        var persona31 = new Persona(); persona31.Documento = 34076206; personas_list.Add(persona31);
        var persona32 = new Persona(); persona32.Documento = 18278630; personas_list.Add(persona32);
        var persona33 = new Persona(); persona33.Documento = 31475729; personas_list.Add(persona33);
        var persona34 = new Persona(); persona34.Documento = 26873230; personas_list.Add(persona34);
        var persona35 = new Persona(); persona35.Documento = 28235516; personas_list.Add(persona35);
        var persona36 = new Persona(); persona36.Documento = 12505765; personas_list.Add(persona36);
        var persona37 = new Persona(); persona37.Documento = 32580172; personas_list.Add(persona37);
        var persona38 = new Persona(); persona38.Documento = 21878946; personas_list.Add(persona38);
        var persona39 = new Persona(); persona39.Documento = 38089406; personas_list.Add(persona39);
        var persona40 = new Persona(); persona40.Documento = 26492768; personas_list.Add(persona40);
        var persona41 = new Persona(); persona41.Documento = 24037139; personas_list.Add(persona41);
        var persona42 = new Persona(); persona42.Documento = 25476587; personas_list.Add(persona42);
        var persona43 = new Persona(); persona43.Documento = 92993744; personas_list.Add(persona43);
        var persona44 = new Persona(); persona44.Documento = 27609747; personas_list.Add(persona44);
        var persona45 = new Persona(); persona45.Documento = 24458552; personas_list.Add(persona45);
        var persona46 = new Persona(); persona46.Documento = 27696285; personas_list.Add(persona46);
        var persona47 = new Persona(); persona47.Documento = 35901825; personas_list.Add(persona47);
        var persona48 = new Persona(); persona48.Documento = 33013383; personas_list.Add(persona48);
        var persona49 = new Persona(); persona49.Documento = 32614020; personas_list.Add(persona49);
        var persona50 = new Persona(); persona50.Documento = 35270001; personas_list.Add(persona50);
        var persona51 = new Persona(); persona51.Documento = 38788606; personas_list.Add(persona51);
        var persona52 = new Persona(); persona52.Documento = 23452791; personas_list.Add(persona52);
        var persona53 = new Persona(); persona53.Documento = 29133531; personas_list.Add(persona53);
        var persona54 = new Persona(); persona54.Documento = 29646177; personas_list.Add(persona54);
        var persona55 = new Persona(); persona55.Documento = 14844992; personas_list.Add(persona55);
        var persona56 = new Persona(); persona56.Documento = 12813075; personas_list.Add(persona56);
        var persona57 = new Persona(); persona57.Documento = 25612213; personas_list.Add(persona57);
        var persona58 = new Persona(); persona58.Documento = 24690529; personas_list.Add(persona58);
        var persona59 = new Persona(); persona59.Documento = 28366079; personas_list.Add(persona59);
        var persona60 = new Persona(); persona60.Documento = 20266813; personas_list.Add(persona60);
        var persona61 = new Persona(); persona61.Documento = 14027242; personas_list.Add(persona61);
        var persona62 = new Persona(); persona62.Documento = 17847240; personas_list.Add(persona62);
        var persona63 = new Persona(); persona63.Documento = 24993296; personas_list.Add(persona63);
        var persona64 = new Persona(); persona64.Documento = 20211857; personas_list.Add(persona64);
        var persona65 = new Persona(); persona65.Documento = 26748150; personas_list.Add(persona65);
        var persona66 = new Persona(); persona66.Documento = 25308724; personas_list.Add(persona66);
        var persona67 = new Persona(); persona67.Documento = 11109316; personas_list.Add(persona67);
        var persona68 = new Persona(); persona68.Documento = 20983613; personas_list.Add(persona68);
        var persona69 = new Persona(); persona69.Documento = 31489849; personas_list.Add(persona69);
        var persona70 = new Persona(); persona70.Documento = 35071579; personas_list.Add(persona70);
        var persona71 = new Persona(); persona71.Documento = 31102562; personas_list.Add(persona71);
        var persona72 = new Persona(); persona72.Documento = 25373399; personas_list.Add(persona72);
        var persona73 = new Persona(); persona73.Documento = 27268012; personas_list.Add(persona73);
        var persona74 = new Persona(); persona74.Documento = 30803855; personas_list.Add(persona74);
        var persona75 = new Persona(); persona75.Documento = 30993585; personas_list.Add(persona75);
        var persona76 = new Persona(); persona76.Documento = 16379331; personas_list.Add(persona76);
        var persona77 = new Persona(); persona77.Documento = 32869764; personas_list.Add(persona77);
        var persona78 = new Persona(); persona78.Documento = 33170442; personas_list.Add(persona78);
        var persona79 = new Persona(); persona79.Documento = 23767398; personas_list.Add(persona79);
        var persona80 = new Persona(); persona80.Documento = 30142371; personas_list.Add(persona80);
        var persona81 = new Persona(); persona81.Documento = 28863383; personas_list.Add(persona81);
        var persona82 = new Persona(); persona82.Documento = 12784319; personas_list.Add(persona82);
        var persona83 = new Persona(); persona83.Documento = 33024604; personas_list.Add(persona83);
        var persona84 = new Persona(); persona84.Documento = 22913337; personas_list.Add(persona84);
        var persona85 = new Persona(); persona85.Documento = 26289729; personas_list.Add(persona85);
        var persona86 = new Persona(); persona86.Documento = 30608803; personas_list.Add(persona86);
        var persona87 = new Persona(); persona87.Documento = 29511247; personas_list.Add(persona87);
        var persona88 = new Persona(); persona88.Documento = 19003337; personas_list.Add(persona88);
        var persona89 = new Persona(); persona89.Documento = 33196440; personas_list.Add(persona89);
        var persona90 = new Persona(); persona90.Documento = 23029545; personas_list.Add(persona90);
        var persona91 = new Persona(); persona91.Documento = 23772197; personas_list.Add(persona91);
        var persona92 = new Persona(); persona92.Documento = 29382205; personas_list.Add(persona92);
        var persona93 = new Persona(); persona93.Documento = 35567691; personas_list.Add(persona93);
        var persona94 = new Persona(); persona94.Documento = 31925817; personas_list.Add(persona94);
        var persona95 = new Persona(); persona95.Documento = 28464845; personas_list.Add(persona95);
        var persona96 = new Persona(); persona96.Documento = 12849918; personas_list.Add(persona96);
        var persona97 = new Persona(); persona97.Documento = 21828053; personas_list.Add(persona97);
        var persona98 = new Persona(); persona98.Documento = 30651121; personas_list.Add(persona98);
        var persona99 = new Persona(); persona99.Documento = 30818256; personas_list.Add(persona99);
        var persona100 = new Persona(); persona100.Documento = 28264650; personas_list.Add(persona100);
        var persona101 = new Persona(); persona101.Documento = 31884694; personas_list.Add(persona101);


        return personas_list;
    }
    private List<Persona> GetEmpleadosExcelFaby()
    {
        List<Persona> personas_list = new List<Persona>();

        var persona0 = new Persona(); persona0.Documento = 17203040; personas_list.Add(persona0);
        var persona1 = new Persona(); persona1.Documento = 13615584; personas_list.Add(persona1);
        var persona2 = new Persona(); persona2.Documento = 18110361; personas_list.Add(persona2);
        var persona3 = new Persona(); persona3.Documento = 7837226; personas_list.Add(persona3);
        var persona4 = new Persona(); persona4.Documento = 14840169; personas_list.Add(persona4);
        var persona5 = new Persona(); persona5.Documento = 27961116; personas_list.Add(persona5);
        var persona6 = new Persona(); persona6.Documento = 8277555; personas_list.Add(persona6);
        var persona7 = new Persona(); persona7.Documento = 16345439; personas_list.Add(persona7);
        var persona8 = new Persona(); persona8.Documento = 14195270; personas_list.Add(persona8);
        var persona9 = new Persona(); persona9.Documento = 6675779; personas_list.Add(persona9);
        var persona10 = new Persona(); persona10.Documento = 13800464; personas_list.Add(persona10);
        var persona11 = new Persona(); persona11.Documento = 23227787; personas_list.Add(persona11);
        var persona12 = new Persona(); persona12.Documento = 20405037; personas_list.Add(persona12);
        var persona13 = new Persona(); persona13.Documento = 26114367; personas_list.Add(persona13);
        var persona14 = new Persona(); persona14.Documento = 17761700; personas_list.Add(persona14);
        var persona15 = new Persona(); persona15.Documento = 14964411; personas_list.Add(persona15);
        var persona16 = new Persona(); persona16.Documento = 10263970; personas_list.Add(persona16);
        var persona17 = new Persona(); persona17.Documento = 20469246; personas_list.Add(persona17);
        var persona18 = new Persona(); persona18.Documento = 7530181; personas_list.Add(persona18);
        var persona19 = new Persona(); persona19.Documento = 18795682; personas_list.Add(persona19);
        var persona20 = new Persona(); persona20.Documento = 16405094; personas_list.Add(persona20);
        var persona21 = new Persona(); persona21.Documento = 6694154; personas_list.Add(persona21);
        var persona22 = new Persona(); persona22.Documento = 16973737; personas_list.Add(persona22);
        var persona23 = new Persona(); persona23.Documento = 6278699; personas_list.Add(persona23);
        var persona24 = new Persona(); persona24.Documento = 23771676; personas_list.Add(persona24);
        var persona25 = new Persona(); persona25.Documento = 10741730; personas_list.Add(persona25);
        var persona26 = new Persona(); persona26.Documento = 13437655; personas_list.Add(persona26);
        var persona27 = new Persona(); persona27.Documento = 25628511; personas_list.Add(persona27);
        var persona28 = new Persona(); persona28.Documento = 13127350; personas_list.Add(persona28);
        var persona29 = new Persona(); persona29.Documento = 18253428; personas_list.Add(persona29);
        var persona30 = new Persona(); persona30.Documento = 28873513; personas_list.Add(persona30);
        var persona31 = new Persona(); persona31.Documento = 17919836; personas_list.Add(persona31);
        var persona32 = new Persona(); persona32.Documento = 23256800; personas_list.Add(persona32);
        var persona33 = new Persona(); persona33.Documento = 21925132; personas_list.Add(persona33);
        var persona34 = new Persona(); persona34.Documento = 28814391; personas_list.Add(persona34);
        var persona35 = new Persona(); persona35.Documento = 23174101; personas_list.Add(persona35);
        var persona36 = new Persona(); persona36.Documento = 7793253; personas_list.Add(persona36);
        var persona37 = new Persona(); persona37.Documento = 17806761; personas_list.Add(persona37);
        var persona38 = new Persona(); persona38.Documento = 18767013; personas_list.Add(persona38);
        var persona39 = new Persona(); persona39.Documento = 20204509; personas_list.Add(persona39);
        var persona40 = new Persona(); persona40.Documento = 6425458; personas_list.Add(persona40);
        var persona41 = new Persona(); persona41.Documento = 6532111; personas_list.Add(persona41);
        var persona42 = new Persona(); persona42.Documento = 29319010; personas_list.Add(persona42);
        var persona43 = new Persona(); persona43.Documento = 5830074; personas_list.Add(persona43);
        var persona44 = new Persona(); persona44.Documento = 7869055; personas_list.Add(persona44);
        var persona45 = new Persona(); persona45.Documento = 14735981; personas_list.Add(persona45);
        var persona46 = new Persona(); persona46.Documento = 10136680; personas_list.Add(persona46);
        var persona47 = new Persona(); persona47.Documento = 6179612; personas_list.Add(persona47);
        var persona48 = new Persona(); persona48.Documento = 6702324; personas_list.Add(persona48);
        var persona49 = new Persona(); persona49.Documento = 14309869; personas_list.Add(persona49);
        var persona50 = new Persona(); persona50.Documento = 10554670; personas_list.Add(persona50);
        var persona51 = new Persona(); persona51.Documento = 10439898; personas_list.Add(persona51);
        var persona52 = new Persona(); persona52.Documento = 17861703; personas_list.Add(persona52);
        var persona53 = new Persona(); persona53.Documento = 8660648; personas_list.Add(persona53);
        var persona54 = new Persona(); persona54.Documento = 28168304; personas_list.Add(persona54);
        var persona55 = new Persona(); persona55.Documento = 17607665; personas_list.Add(persona55);
        var persona56 = new Persona(); persona56.Documento = 6075183; personas_list.Add(persona56);
        var persona57 = new Persona(); persona57.Documento = 18222748; personas_list.Add(persona57);
        var persona58 = new Persona(); persona58.Documento = 21986631; personas_list.Add(persona58);
        var persona59 = new Persona(); persona59.Documento = 6150973; personas_list.Add(persona59);
        var persona60 = new Persona(); persona60.Documento = 28488073; personas_list.Add(persona60);
        var persona61 = new Persona(); persona61.Documento = 12481571; personas_list.Add(persona61);
        var persona62 = new Persona(); persona62.Documento = 11783558; personas_list.Add(persona62);
        var persona63 = new Persona(); persona63.Documento = 12080612; personas_list.Add(persona63);
        var persona64 = new Persona(); persona64.Documento = 21486160; personas_list.Add(persona64);
        var persona65 = new Persona(); persona65.Documento = 16161845; personas_list.Add(persona65);
        var persona66 = new Persona(); persona66.Documento = 12317441; personas_list.Add(persona66);
        var persona67 = new Persona(); persona67.Documento = 8255244; personas_list.Add(persona67);
        var persona68 = new Persona(); persona68.Documento = 11182289; personas_list.Add(persona68);
        var persona69 = new Persona(); persona69.Documento = 18365704; personas_list.Add(persona69);
        var persona70 = new Persona(); persona70.Documento = 14324755; personas_list.Add(persona70);
        var persona71 = new Persona(); persona71.Documento = 10809428; personas_list.Add(persona71);
        var persona72 = new Persona(); persona72.Documento = 17232051; personas_list.Add(persona72);
        var persona73 = new Persona(); persona73.Documento = 11320409; personas_list.Add(persona73);
        var persona74 = new Persona(); persona74.Documento = 17660567; personas_list.Add(persona74);
        var persona75 = new Persona(); persona75.Documento = 13313748; personas_list.Add(persona75);
        var persona76 = new Persona(); persona76.Documento = 6554210; personas_list.Add(persona76);
        var persona77 = new Persona(); persona77.Documento = 11454280; personas_list.Add(persona77);
        var persona78 = new Persona(); persona78.Documento = 8346081; personas_list.Add(persona78);
        var persona79 = new Persona(); persona79.Documento = 12588232; personas_list.Add(persona79);
        var persona80 = new Persona(); persona80.Documento = 23766836; personas_list.Add(persona80);
        var persona81 = new Persona(); persona81.Documento = 22489297; personas_list.Add(persona81);
        var persona82 = new Persona(); persona82.Documento = 27769798; personas_list.Add(persona82);
        var persona83 = new Persona(); persona83.Documento = 12504384; personas_list.Add(persona83);
        var persona84 = new Persona(); persona84.Documento = 13313581; personas_list.Add(persona84);
        var persona85 = new Persona(); persona85.Documento = 17229657; personas_list.Add(persona85);
        var persona86 = new Persona(); persona86.Documento = 13945818; personas_list.Add(persona86);
        var persona87 = new Persona(); persona87.Documento = 7787921; personas_list.Add(persona87);
        var persona88 = new Persona(); persona88.Documento = 10587494; personas_list.Add(persona88);
        var persona89 = new Persona(); persona89.Documento = 13214723; personas_list.Add(persona89);
        var persona90 = new Persona(); persona90.Documento = 16043568; personas_list.Add(persona90);
        var persona91 = new Persona(); persona91.Documento = 6079105; personas_list.Add(persona91);
        var persona92 = new Persona(); persona92.Documento = 8667020; personas_list.Add(persona92);
        var persona93 = new Persona(); persona93.Documento = 23454243; personas_list.Add(persona93);
        var persona94 = new Persona(); persona94.Documento = 36064868; personas_list.Add(persona94);
        var persona95 = new Persona(); persona95.Documento = 16591734; personas_list.Add(persona95);
        var persona96 = new Persona(); persona96.Documento = 6178466; personas_list.Add(persona96);
        var persona97 = new Persona(); persona97.Documento = 18497519; personas_list.Add(persona97);
        var persona98 = new Persona(); persona98.Documento = 6717619; personas_list.Add(persona98);
        var persona99 = new Persona(); persona99.Documento = 6179609; personas_list.Add(persona99);
        var persona100 = new Persona(); persona100.Documento = 17595395; personas_list.Add(persona100);
        var persona101 = new Persona(); persona101.Documento = 14860595; personas_list.Add(persona101);
        var persona102 = new Persona(); persona102.Documento = 23453572; personas_list.Add(persona102);
        var persona103 = new Persona(); persona103.Documento = 4774722; personas_list.Add(persona103);
        var persona104 = new Persona(); persona104.Documento = 4898063; personas_list.Add(persona104);
        var persona105 = new Persona(); persona105.Documento = 23865252; personas_list.Add(persona105);
        var persona106 = new Persona(); persona106.Documento = 5945215; personas_list.Add(persona106);
        var persona107 = new Persona(); persona107.Documento = 20527145; personas_list.Add(persona107);
        var persona108 = new Persona(); persona108.Documento = 22588287; personas_list.Add(persona108);
        var persona109 = new Persona(); persona109.Documento = 12949892; personas_list.Add(persona109);
        var persona110 = new Persona(); persona110.Documento = 7593730; personas_list.Add(persona110);
        var persona111 = new Persona(); persona111.Documento = 20751155; personas_list.Add(persona111);
        var persona112 = new Persona(); persona112.Documento = 16941162; personas_list.Add(persona112);
        var persona113 = new Persona(); persona113.Documento = 23205489; personas_list.Add(persona113);
        var persona114 = new Persona(); persona114.Documento = 10373016; personas_list.Add(persona114);
        var persona115 = new Persona(); persona115.Documento = 14647373; personas_list.Add(persona115);
        var persona116 = new Persona(); persona116.Documento = 6173675; personas_list.Add(persona116);
        var persona117 = new Persona(); persona117.Documento = 5219014; personas_list.Add(persona117);
        var persona118 = new Persona(); persona118.Documento = 16345771; personas_list.Add(persona118);
        var persona119 = new Persona(); persona119.Documento = 20636223; personas_list.Add(persona119);
        var persona120 = new Persona(); persona120.Documento = 20464207; personas_list.Add(persona120);
        var persona121 = new Persona(); persona121.Documento = 12176696; personas_list.Add(persona121);
        var persona122 = new Persona(); persona122.Documento = 14855944; personas_list.Add(persona122);
        var persona123 = new Persona(); persona123.Documento = 32110806; personas_list.Add(persona123);
        var persona124 = new Persona(); persona124.Documento = 5473894; personas_list.Add(persona124);
        var persona125 = new Persona(); persona125.Documento = 11358653; personas_list.Add(persona125);
        var persona126 = new Persona(); persona126.Documento = 5432122; personas_list.Add(persona126);
        var persona127 = new Persona(); persona127.Documento = 20379742; personas_list.Add(persona127);
        var persona128 = new Persona(); persona128.Documento = 18311122; personas_list.Add(persona128);
        var persona129 = new Persona(); persona129.Documento = 12511139; personas_list.Add(persona129);
        var persona130 = new Persona(); persona130.Documento = 13687754; personas_list.Add(persona130);
        var persona131 = new Persona(); persona131.Documento = 10084892; personas_list.Add(persona131);
        var persona132 = new Persona(); persona132.Documento = 24043327; personas_list.Add(persona132);
        var persona133 = new Persona(); persona133.Documento = 10966701; personas_list.Add(persona133);
        var persona134 = new Persona(); persona134.Documento = 14327934; personas_list.Add(persona134);
        var persona135 = new Persona(); persona135.Documento = 4516189; personas_list.Add(persona135);
        var persona136 = new Persona(); persona136.Documento = 17028230; personas_list.Add(persona136);
        var persona137 = new Persona(); persona137.Documento = 10793075; personas_list.Add(persona137);
        var persona138 = new Persona(); persona138.Documento = 11504951; personas_list.Add(persona138);
        var persona139 = new Persona(); persona139.Documento = 18583408; personas_list.Add(persona139);
        var persona140 = new Persona(); persona140.Documento = 7610913; personas_list.Add(persona140);
        var persona141 = new Persona(); persona141.Documento = 11489469; personas_list.Add(persona141);
        var persona142 = new Persona(); persona142.Documento = 20946442; personas_list.Add(persona142);
        var persona143 = new Persona(); persona143.Documento = 13807376; personas_list.Add(persona143);
        var persona144 = new Persona(); persona144.Documento = 22598381; personas_list.Add(persona144);
        var persona145 = new Persona(); persona145.Documento = 14946395; personas_list.Add(persona145);
        var persona146 = new Persona(); persona146.Documento = 10548351; personas_list.Add(persona146);
        var persona147 = new Persona(); persona147.Documento = 13477606; personas_list.Add(persona147);
        var persona148 = new Persona(); persona148.Documento = 11443393; personas_list.Add(persona148);
        var persona149 = new Persona(); persona149.Documento = 8558937; personas_list.Add(persona149);
        var persona150 = new Persona(); persona150.Documento = 16528239; personas_list.Add(persona150);
        var persona151 = new Persona(); persona151.Documento = 25474503; personas_list.Add(persona151);
        var persona152 = new Persona(); persona152.Documento = 31932930; personas_list.Add(persona152);
        var persona153 = new Persona(); persona153.Documento = 22049417; personas_list.Add(persona153);
        var persona154 = new Persona(); persona154.Documento = 18435564; personas_list.Add(persona154);
        var persona155 = new Persona(); persona155.Documento = 16938119; personas_list.Add(persona155);
        var persona156 = new Persona(); persona156.Documento = 13585812; personas_list.Add(persona156);
        var persona157 = new Persona(); persona157.Documento = 6360891; personas_list.Add(persona157);
        var persona158 = new Persona(); persona158.Documento = 14563467; personas_list.Add(persona158);
        var persona159 = new Persona(); persona159.Documento = 6063484; personas_list.Add(persona159);
        var persona160 = new Persona(); persona160.Documento = 28746311; personas_list.Add(persona160);
        var persona161 = new Persona(); persona161.Documento = 17863006; personas_list.Add(persona161);
        var persona162 = new Persona(); persona162.Documento = 22570554; personas_list.Add(persona162);
        var persona163 = new Persona(); persona163.Documento = 16533276; personas_list.Add(persona163);
        var persona164 = new Persona(); persona164.Documento = 11293897; personas_list.Add(persona164);
        var persona165 = new Persona(); persona165.Documento = 10284175; personas_list.Add(persona165);
        var persona166 = new Persona(); persona166.Documento = 5091453; personas_list.Add(persona166);
        var persona167 = new Persona(); persona167.Documento = 11091247; personas_list.Add(persona167);
        var persona168 = new Persona(); persona168.Documento = 5964699; personas_list.Add(persona168);
        var persona169 = new Persona(); persona169.Documento = 5663368; personas_list.Add(persona169);
        var persona170 = new Persona(); persona170.Documento = 10013414; personas_list.Add(persona170);
        var persona171 = new Persona(); persona171.Documento = 6544040; personas_list.Add(persona171);
        var persona172 = new Persona(); persona172.Documento = 20521311; personas_list.Add(persona172);
        var persona173 = new Persona(); persona173.Documento = 6354582; personas_list.Add(persona173);
        var persona174 = new Persona(); persona174.Documento = 21654223; personas_list.Add(persona174);
        var persona175 = new Persona(); persona175.Documento = 13694355; personas_list.Add(persona175);
        var persona176 = new Persona(); persona176.Documento = 20634172; personas_list.Add(persona176);
        var persona177 = new Persona(); persona177.Documento = 22128263; personas_list.Add(persona177);
        var persona178 = new Persona(); persona178.Documento = 23469766; personas_list.Add(persona178);
        var persona179 = new Persona(); persona179.Documento = 12943725; personas_list.Add(persona179);
        var persona180 = new Persona(); persona180.Documento = 16553361; personas_list.Add(persona180);
        var persona181 = new Persona(); persona181.Documento = 13361020; personas_list.Add(persona181);
        var persona182 = new Persona(); persona182.Documento = 11597867; personas_list.Add(persona182);
        var persona183 = new Persona(); persona183.Documento = 14121705; personas_list.Add(persona183);
        var persona184 = new Persona(); persona184.Documento = 12759257; personas_list.Add(persona184);
        var persona185 = new Persona(); persona185.Documento = 11360721; personas_list.Add(persona185);
        var persona186 = new Persona(); persona186.Documento = 5268053; personas_list.Add(persona186);
        var persona187 = new Persona(); persona187.Documento = 4514173; personas_list.Add(persona187);
        var persona188 = new Persona(); persona188.Documento = 23519798; personas_list.Add(persona188);
        var persona189 = new Persona(); persona189.Documento = 17023204; personas_list.Add(persona189);
        var persona190 = new Persona(); persona190.Documento = 13120900; personas_list.Add(persona190);
        var persona191 = new Persona(); persona191.Documento = 13855365; personas_list.Add(persona191);
        var persona192 = new Persona(); persona192.Documento = 21787171; personas_list.Add(persona192);
        var persona193 = new Persona(); persona193.Documento = 18380273; personas_list.Add(persona193);
        var persona194 = new Persona(); persona194.Documento = 10264042; personas_list.Add(persona194);
        var persona195 = new Persona(); persona195.Documento = 21795191; personas_list.Add(persona195);
        var persona196 = new Persona(); persona196.Documento = 18318955; personas_list.Add(persona196);
        var persona197 = new Persona(); persona197.Documento = 25540384; personas_list.Add(persona197);
        var persona198 = new Persona(); persona198.Documento = 13996563; personas_list.Add(persona198);
        var persona199 = new Persona(); persona199.Documento = 16755931; personas_list.Add(persona199);
        var persona200 = new Persona(); persona200.Documento = 6707986; personas_list.Add(persona200);
        var persona201 = new Persona(); persona201.Documento = 16187536; personas_list.Add(persona201);
        var persona202 = new Persona(); persona202.Documento = 10868026; personas_list.Add(persona202);
        var persona203 = new Persona(); persona203.Documento = 3895266; personas_list.Add(persona203);
        var persona204 = new Persona(); persona204.Documento = 18272517; personas_list.Add(persona204);
        var persona205 = new Persona(); persona205.Documento = 14277836; personas_list.Add(persona205);
        var persona206 = new Persona(); persona206.Documento = 13137243; personas_list.Add(persona206);
        var persona207 = new Persona(); persona207.Documento = 12472226; personas_list.Add(persona207);
        var persona208 = new Persona(); persona208.Documento = 29508101; personas_list.Add(persona208);
        var persona209 = new Persona(); persona209.Documento = 11488589; personas_list.Add(persona209);
        var persona210 = new Persona(); persona210.Documento = 6373464; personas_list.Add(persona210);
        var persona211 = new Persona(); persona211.Documento = 13740727; personas_list.Add(persona211);
        var persona212 = new Persona(); persona212.Documento = 18154418; personas_list.Add(persona212);
        var persona213 = new Persona(); persona213.Documento = 20618482; personas_list.Add(persona213);
        var persona214 = new Persona(); persona214.Documento = 12753847; personas_list.Add(persona214);
        var persona215 = new Persona(); persona215.Documento = 22809741; personas_list.Add(persona215);
        var persona216 = new Persona(); persona216.Documento = 16440015; personas_list.Add(persona216);
        var persona217 = new Persona(); persona217.Documento = 17753488; personas_list.Add(persona217);
        var persona218 = new Persona(); persona218.Documento = 11908400; personas_list.Add(persona218);
        var persona219 = new Persona(); persona219.Documento = 13314887; personas_list.Add(persona219);
        var persona220 = new Persona(); persona220.Documento = 18322105; personas_list.Add(persona220);
        var persona221 = new Persona(); persona221.Documento = 23463926; personas_list.Add(persona221);
        var persona222 = new Persona(); persona222.Documento = 6179994; personas_list.Add(persona222);
        var persona223 = new Persona(); persona223.Documento = 13807867; personas_list.Add(persona223);
        var persona224 = new Persona(); persona224.Documento = 24431965; personas_list.Add(persona224);
        var persona225 = new Persona(); persona225.Documento = 6532064; personas_list.Add(persona225);
        var persona226 = new Persona(); persona226.Documento = 29064932; personas_list.Add(persona226);
        var persona227 = new Persona(); persona227.Documento = 11423458; personas_list.Add(persona227);
        var persona228 = new Persona(); persona228.Documento = 6532049; personas_list.Add(persona228);
        var persona229 = new Persona(); persona229.Documento = 16613236; personas_list.Add(persona229);
        var persona230 = new Persona(); persona230.Documento = 10936508; personas_list.Add(persona230);
        var persona231 = new Persona(); persona231.Documento = 14480543; personas_list.Add(persona231);

        var persona232 = new Persona(); persona232.Documento = 25130550; personas_list.Add(persona232);
        var persona233 = new Persona(); persona233.Documento = 20225799; personas_list.Add(persona233);
        return personas_list;
    }
}
