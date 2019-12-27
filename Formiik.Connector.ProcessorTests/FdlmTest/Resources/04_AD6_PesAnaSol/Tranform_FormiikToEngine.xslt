<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                exclude-result-prefixes="msxsl">
    <xsl:output method="text" indent="yes"/>
    <xsl:template match="root">
        <root>
            {
                "Ppi1_CuaMieTieHog": ["<xsl:value-of select="Ppi1_CuaMieTieHog"/>"],
                "CanMieUniFam": "<xsl:value-of select="CanMieUniFam"/>",
                "CanPerDepCli": "<xsl:value-of select="CanPerDepCli"/>",
                "CanHijCli": "<xsl:value-of select="CanHijCli"/>",
                "Ppi2_NinActAsiEsc": ["<xsl:value-of select="Ppi2_NinActAsiEsc"/>"],
                "Ppi3_MieConNivEduAlt": "<xsl:value-of select="Ppi3_MieConNivEduAlt"/>",
                "TipSegSoc": "<xsl:value-of select="TipSegSoc"/>",
                "TitFuePEP": "<xsl:value-of select="TitFuePEP"/>",
                "CarPubDesCli": "<xsl:value-of select="CarPubDesCli"/>",
                "TitVictPosCon": "<xsl:value-of select="TitVictPosCon"/>",
                "CueConCer": "<xsl:value-of select="CueConCer"/>",
                "Ppi4_MieHogTieTraCon": "<xsl:value-of select="Ppi4_MieHogTieTraCon"/>",
                "Ppi5_MieHogObrEmp": "<xsl:value-of select="Ppi5_MieHogObrEmp"/>",
                "Ppi6_MieHogPatEmp": "<xsl:value-of select="Ppi6_MieHogPatEmp"/>",
                "AdiNegEsEmpCli": "<xsl:value-of select="AdiNegEsEmpCli"/>",
                "DatLabCli":
                {
                    "AntVinEmp":"<xsl:value-of select="AntVinEmp"/>",
                    "NomEmpLabCli":"<xsl:value-of select="NomEmpLabCli"/>",
                    "Direccion":
                        {
                            "DepartamentoMunicipioBarrio":["<xsl:value-of select="IdeDepEmpLabCli"/>","<xsl:value-of select="IdeMunEmpLabCli"/>","<xsl:value-of select="IdeBarEmpLabCli"/>"],
                            "DirEmp":"<xsl:value-of select="DirEmp"/>"
                        },
                    "CarEmpLabCli":"<xsl:value-of select="CarEmpLabCli"/>",
                    "SalEmpLabCli":"<xsl:value-of select="SalEmpLabCli"/>",
                    "NomConEmpLabCli":"<xsl:value-of select="NomConEmpLabCli"/>",
                    "TelConEmpLabCli":"<xsl:value-of select="TelConEmpLabCli"/>",
                    "ObsConLabli":"<xsl:value-of select="ObsConLabli"/>"
                },
                "CarConEmpLabCli": "<xsl:value-of select="CarConEmpLabCli"/>",
                "IdentificacionConyuge":
                    {
                        "TipIdeCon":["<xsl:value-of select="TipIdeCon"/>"],
                        "NumIdeConExtrangeria":"<xsl:value-of select="NumIdeCon"/>"
                    },
                "NumIdeConOri": "<xsl:value-of select="NumIdeConOri"/>",
                "MenResConCon": "<xsl:value-of select="MenResConCon"/>",
                "CodRieValLisConCon": "<xsl:value-of select="CodRieValLisConCon"/>",
                "LisConValLisConCon": "<xsl:value-of select="LisConValLisConCon"/>",
                "AdvLisConCon": "<xsl:value-of select="AdvLisConCon"/>",
                "Conyuge":
                    {
                        "PriNomCon":"<xsl:value-of select="PriNomCon"/>",
                        "SegNomCon":"<xsl:value-of select="SegNomCon"/>",
                        "PriApeCon":"<xsl:value-of select="PriApeCon"/>",
                        "SegApeCon":"<xsl:value-of select="SegApeCon"/>",
                        "FecNacCon":"<xsl:value-of select="FecNacCon"/>",
                        "GenCon":["<xsl:value-of select="GenCon"/>"]
                    },
                "FirCreCon": "<xsl:value-of select="FirCreCon"/>",
                "MotFirCreCon": "<xsl:value-of select="MotFirCreCon"/>",
                "VisCenRieCon": "<xsl:value-of select="VisCenRieCon"/>",
                "EjeConCenRieCon": "<xsl:value-of select="EjeConCenRieCon"/>",
                "AprCenRieCon": "<xsl:value-of select="AprCenRieCon"/>",
                "CauDenCenRieCon": ["<xsl:value-of select="CauDenCenRieCon"/>"],
                "ComCauNegCenRieCon": "<xsl:value-of select="ComCauNegCenRieCon"/>",
                "FecExpIdeCon": "<xsl:value-of select="FecExpIdeCon"/>",
                "NomDepExpDocCon": ["<xsl:value-of select="IdeDepExpDocCon"/>", "<xsl:value-of select="IdeMunExpDocCon"/>"],
                "TelCon": "<xsl:value-of select="TelCon"/>",
                "CelCon": "<xsl:value-of select="CelCon"/>",
                "NivEduCon": ["<xsl:value-of select="NivEduCon"/>"],
                "ConFuePEP": "<xsl:value-of select="ConFuePEP"/>",
                "CarPubDesCon": "<xsl:value-of select="CarPubDesCon"/>",
                "ActDelCon": ["<xsl:value-of select="ActDelCon"/>"],
                "MotNoActNegCon": "<xsl:value-of select="MotNoActNegCon"/>",
                "EmpLabCon": "<xsl:value-of select="EmpLabCon"/>",
                "AntVinEmpCon": "<xsl:value-of select="AntVinEmpCon"/>",
                "DatEmpLabCon":
                    {
                        "DirEmpLabCon":"<xsl:value-of select="DirEmpLabCon"/>",
                        "Direccion":
                            {
                                "DeptoMunicipioBarrioDomicilio":["<xsl:value-of select="IdeDepEmpLabCon"/>","<xsl:value-of select="IdeMunEmpLabCon"/>","<xsl:value-of select="IdeBarEmpLabCon"/>"]
                            }
                    },
                "CarEmpLabCon": "<xsl:value-of select="CarEmpLabCon"/>",
                "SalEmpLabCon": "<xsl:value-of select="SalEmpLabCon"/>",
                "NomConEmpLabCon": "<xsl:value-of select="NomConEmpLabCon"/>",
                "CarConEmpLabCon": "<xsl:value-of select="CarConEmpLabCon"/>",
                "TelConEmpLabCon": "<xsl:value-of select="TelConEmpLabCon"/>",
                "ObsConLabCon": "<xsl:value-of select="ObsConLabCon"/>",
                "ObsGenCon": "<xsl:value-of select="ObsGenCon"/>",
                "TipVivCli": ["<xsl:value-of select="TipVivCli"/>"],
                "InfVivFam": "<xsl:value-of select="InfVivFam"/>",
                "NomFamViv": "<xsl:value-of select="NomFamViv"/>",
                "ParFamViv": ["<xsl:value-of select="ParFamViv"/>"],
                "CanArrCasFam": "<xsl:value-of select="CanArrCasFam"/>",
                "ValArrCanFam": "<xsl:value-of select="ValArrCanFam"/>",
                "TelFamArr": "<xsl:value-of select="TelFamArr"/>",
                "LlaTelFamArr": "<xsl:value-of select="LlaTelFamArr"/>",
                "CelFamArr": "<xsl:value-of select="CelFamArr"/>",
                "LlaCelFamArr": "<xsl:value-of select="LlaCelFamArr"/>",
                "ValTelFamArr": "<xsl:value-of select="ValTelFamArr"/>",
                "ObsConArr": "<xsl:value-of select="ObsConArr"/>",
                "TieResViv": "<xsl:value-of select="TieResViv"/>",
                "EsLegViv": "<xsl:value-of select="EsLegViv"/>",
                "EstPreTit": ["<xsl:value-of select="EstPreTit"/>"],
                "FotRecPubTit": "<xsl:value-of select="FotRecPubTit"/>",
                "TieMasBieInm": "<xsl:value-of select="TieMasBieInm"/>",
                "CanBieInmAdi": "<xsl:value-of select="CanBieInmAdi"/>",
                "EsLegBieInmAdi": "<xsl:value-of select="EsLegBieInmAdi"/>",
                "BieInmAdiProFin": ["<xsl:value-of select="BieInmAdiProFin"/>"],
                "NomArrViv": "<xsl:value-of select="NomArrViv"/>",
                "ValArrViv": "<xsl:value-of select="ValArrViv"/>",
                "TelArrViv": "<xsl:value-of select="TelArrViv"/>",
                "CelArrViv": "<xsl:value-of select="CelArrViv"/>",
                "ObsArrAct": "<xsl:value-of select="ObsArrAct"/>",
                "AntVivArr": "<xsl:value-of select="AntVivArr"/>",
                "NomArrAnt": "<xsl:value-of select="NomArrAnt"/>",
                "ValArrAnt": "<xsl:value-of select="ValArrAnt"/>",
                "TelArrAnt": "<xsl:value-of select="TelArrAnt"/>",
                "CelArrAnt": "<xsl:value-of select="CelArrAnt"/>",
                "ObsArrAnt": "<xsl:value-of select="ObsArrAnt"/>",
                "CueAguPotViv": "<xsl:value-of select="CueAguPotViv"/>",
                "CueAccInt": "<xsl:value-of select="CueAccInt"/>",
                "DesDonCon": ["<xsl:value-of select="DesDonCon"/>"],
                "ReaTraMonExt": "<xsl:value-of select="ReaTraMonExt"/>",
                "IdeSecEcoMon":["<xsl:value-of select="IdeSecEcoMon"/>","<xsl:value-of select="IdeActEcoMon"/>"],
                "TipMonCom": ["<xsl:value-of select="TipMonCom"/>"],
                "MonMenTra": "<xsl:value-of select="MonMenTra"/>",
                "FecPosNeg": "<xsl:value-of select="FecPosNeg"/>",
                "FecExpNeg": "<xsl:value-of select="FecExpNeg"/>",
                "NumEmpFijNeg": "<xsl:value-of select="NumEmpFijNeg"/>",
                "NumEmpTemNeg": "<xsl:value-of select="NumEmpTemNeg"/>",
                "NumEmpNeg": "<xsl:value-of select="NumEmpNeg"/>",
                "NegTieCamCom": "<xsl:value-of select="NegTieCamCom"/>",
                "NegTieRut": "<xsl:value-of select="NegTieRut"/>",
                "TipLocNeg": ["<xsl:value-of select="TipLocNeg"/>"],
                "NomComArrNeg": "<xsl:value-of select="NomComArrNeg"/>",
                "TelArrNeg": "<xsl:value-of select="TelArrNeg"/>",
                "CelArrNeg": "<xsl:value-of select="CelArrNeg"/>",
                "CanArrNeg": "<xsl:value-of select="CanArrNeg"/>",
                "FecFunLoc": "<xsl:value-of select="FecFunLoc"/>",
                "ValFecPosLoc": "<xsl:value-of select="ValFecPosLoc"/>",
                "ObsArrLoc": "<xsl:value-of select="ObsArrLoc"/>",
                "NomVerZonCom": "<xsl:value-of select="NomVerZonCom"/>",
                "DirVerZonCom": "<xsl:value-of select="DirVerZonCom"/>",
                "TelVerZonCom": "<xsl:value-of select="TelVerZonCom"/>",
                "ZonTieActEco": "<xsl:value-of select="ZonTieActEco"/>",
                "IdeSecRefZon": ["<xsl:value-of select="IdeSecRefZon"/>","<xsl:value-of select="IdeActRefZon"/>"],
                "EsCliVigVerZonCom": "<xsl:value-of select="EsCliVigVerZonCom"/>",
                "EstIntCreVerZonCom": ["<xsl:value-of select="EstIntCreVerZonCom"/>"],
                "ProVisVerZonCom": "<xsl:value-of select="ProVisVerZonCom"/>",
                "ObsVerZonCom": "<xsl:value-of select="ObsVerZonCom"/>",
                "EstDelNeg": ["<xsl:value-of select="EstDelNeg"/>"],
                "CanTitIguViv": "<xsl:value-of select="CanTitIguViv"/>",
                "CuoMenPuePag": "<xsl:value-of select="CuoMenPuePag"/>",
                "DiaDePagOpo": ["<xsl:value-of select="DiaDePagOpo"/>"],
                "ProAhoMen": "<xsl:value-of select="ProAhoMen"/>",
                "ComAnaCre": "<xsl:value-of select="ComAnaCre"/>"
            }
        </root>
    </xsl:template>
</xsl:stylesheet>
