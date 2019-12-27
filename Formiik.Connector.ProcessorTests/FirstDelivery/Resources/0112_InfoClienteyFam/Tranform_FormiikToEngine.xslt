<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                exclude-result-prefixes="msxsl">
    <xsl:output method="text" indent="yes"/>
    <xsl:template match="root">
        <root>
            {
            "Titular": {
                "TipoDocumento": ["<xsl:value-of select="TipDocCliInfo" />"],
                "PaisExpedicion": ["<xsl:value-of select="PaiExpCliInfo" />"],
                "NumeroDocumento": "<xsl:value-of select="IdReaderCedula_CedulaInfo" />",
                "PrimerNombre": "<xsl:value-of select="IdReaderPrimerNombre_PrimerNombre" />",
                "SegundoApellido": "<xsl:value-of select="IdReaderSegundoApellido_ApellidoMat" />",
                "PrimerApellido": "<xsl:value-of select="IdReaderPrimerApellido_ApellidoPat" />",
                "SegundoNombre": "<xsl:value-of select="IdReaderSegundoNombre_SegundoNombre" />",
                "FechaNacimiento": "<xsl:value-of select="FechNac" />",
                "Genero": ["<xsl:value-of select="IdReaderSexo_Sexo" />"],
                "EstadoCivil": ["<xsl:value-of select="EstadoCivil" />"],
                "NivelEducativo": ["<xsl:value-of select="NivEduc" />"]
                },
            "Conyuge": {
            "ActividadConyuge": [ "<xsl:value-of select="DatosPLCon/FormEditResponse/DatosConyuge/DatosPeryLabCon/ActiCon" />" ],
            "DatosConyuge": {
                    "TipoDocumento": ["<xsl:value-of select="DatosPLCon/FormEditResponse/DatosConyuge/DatosPeryLabCon/TipDocCon" />"],
                    "PaisExpedicion": ["<xsl:value-of select="DatosPLCon/FormEditResponse/DatosConyuge/DatosPeryLabCon/PaiExpCon" />"],
                    "NumeroDocumento": "<xsl:value-of select="DatosPLCon/FormEditResponse/DatosConyuge/DatosPeryLabCon/IdReaderCedula_CedulaCon" />",
                    "PrimerNombre": "<xsl:value-of select="DatosPLCon/FormEditResponse/DatosConyuge/DatosPeryLabCon/NombresCon" />",
                    "SegundoNombre": "<xsl:value-of select="DatosPLCon/FormEditResponse/DatosConyuge/DatosPeryLabCon/IdReaderSegundoNombre_SegundoNombreCon" />",
                    "PrimerApellido": "<xsl:value-of select="DatosPLCon/FormEditResponse/DatosConyuge/DatosPeryLabCon/IdReaderPrimerApellido_ApellidoPatCon" />",
                    "SegundoApellido": "<xsl:value-of select="DatosPLCon/FormEditResponse/DatosConyuge/DatosPeryLabCon/IdReaderSegundoApellido_ApellidoMatCon" />",
                    "FechaNacimiento": "<xsl:value-of select="DatosPLCon/FormEditResponse/DatosConyuge/DatosPeryLabCon/FechNacCon" />",
                    "EstadoCivil": null,
                    "Genero": null,
                    "NivelEducativo": ["<xsl:value-of select="DatosPLCon/FormEditResponse/DatosConyuge/DatosPeryLabCon/NivEducCon" />"]
                }
            },
            "ContactoConyuge": {
                "Telefono": "<xsl:value-of select="DatosPLCon/FormEditResponse/DatosConyuge/DatosPeryLabCon/TelDomCon" />",
                "TelefonoCelular": "<xsl:value-of select="DatosPLCon/FormEditResponse/DatosConyuge/DatosPeryLabCon/CelPerCon" />",
                "CorreoElectronico": "<xsl:value-of select="DatosPLCon/FormEditResponse/DatosConyuge/DatosPeryLabCon/CorEleCon" />",
                "Direccion": ""
            },
            "TiempoResidencia": "<xsl:value-of select="DatDom/FormEditResponse/DatosDomicilio/DatosDomicilio/TiempoResid" />",
            "RentaMensualArrendado": "<xsl:value-of select="DatDom/FormEditResponse/DatosDomicilio/DatosDomicilio/RentaMns" />",
            "CostoAnualPredial": "<xsl:value-of select="DatDom/FormEditResponse/DatosDomicilio/DatosDomicilio/CostAnPred" />",
            "ValorPropiedadFinanciado": "<xsl:value-of select="DatDom/FormEditResponse/DatosDomicilio/DatosDomicilio/ValorProp" />",
            "PagoMensualFinanciado": "<xsl:value-of select="DatDom/FormEditResponse/DatosDomicilio/DatosDomicilio/PagoMens" />",
            "NombreArrendador": "<xsl:value-of select="DatDom/FormEditResponse/DatosDomicilio/DatosDomicilio/NombArrend" />",
            "TelefonoArrendador": "<xsl:value-of select="DatDom/FormEditResponse/DatosDomicilio/DatosDomicilio/TelArrend" />",
            "CorreoElectronicoArrendador": "<xsl:value-of select="DatDom/FormEditResponse/DatosDomicilio/DatosDomicilio/CorEleArrend" />",
            "NombreDuenioHogarFamiliar": "<xsl:value-of select="DatDom/FormEditResponse/DatosDomicilio/DatosDomicilio/NombDueno" />",
            "TelefonoDuenioHogarFamiliar": "<xsl:value-of select="DatDom/FormEditResponse/DatosDomicilio/DatosDomicilio/TelDueno" />",
            "CorreoElectronicoDuenioHogarFamiliar": "<xsl:value-of select="DatDom/FormEditResponse/DatosDomicilio/DatosDomicilio/CorEleDueno" />",
            "AntiguedadPropiedad": "<xsl:value-of select="DatDom/FormEditResponse/DatosDomicilio/DatosDomicilio/AntigProp" />",
            "CuentaConAguaPotable": "<xsl:value-of select="DatDom/FormEditResponse/DatosDomicilio/DatosDomicilio/CuentaAguaPot" />",
            "CuentaConAccesoAInternet": "<xsl:value-of select="DatDom/FormEditResponse/DatosDomicilio/DatosDomicilio/CuentaAccInter" />",
            "ContactoTitular": {
                "Direccion": {
                        "DepartamentoMunicipioBarrio": ["<xsl:value-of select="NomDepBarDomCli" />","<xsl:value-of select="NomMunBarDomCli" />","<xsl:value-of select="NomMunBarDomCli" />" ],
                        "CalleYNumero": "<xsl:value-of select="CalleNum" />"
                    },
                    "CorreoElectronico": "<xsl:value-of select="CorEleCli" />",
                    "Telefono":  "<xsl:value-of select="TelDomCli" />",
                    "TelefonoCelular": "<xsl:value-of select="CelPerCli" />"
            },
            "TitularEsEmpleado": "<xsl:value-of select="CliEmpl" />",
            "AntiguedadEmpleoTitular": "<xsl:value-of select="DatEmp/FormEditResponse/DatosLaborales/DatosLaborales/AntigEmpCli" />",
            "EmpresaDondeLaboraTitular": "<xsl:value-of select="DatEmp/FormEditResponse/DatosLaborales/DatosLaborales/EmpresaCli" />",
            "SalarioEmpleoTitular": "<xsl:value-of select="DatEmp/FormEditResponse/DatosLaborales/DatosLaborales/SalEmpCli" />",
            "DireccionEmpresaEmpleoTitular": "<xsl:value-of select="DatEmp/FormEditResponse/DatosLaborales/DatosLaborales/DirEmpCli" />",
            "TelefonoEmpresaEmpleoTitular": "<xsl:value-of select="DatEmp/FormEditResponse/DatosLaborales/DatosLaborales/TelEmpCli" />",
            "NombreContactoEmpleoTitular": "<xsl:value-of select="DatEmp/FormEditResponse/DatosLaborales/DatosLaborales/NomContEmp" />",
            "NumeroMiembrosFamilia": "<xsl:value-of select="DatosNuc/FormEditResponse/DatosNucleo/DatNucleo/NumMiemFam" />",
            "TotalPersonasACargo": "<xsl:value-of select="DatosNuc/FormEditResponse/DatosNucleo/DatNucleo/TotPersCargo" />",
            "NumeroHijos": "<xsl:value-of select="DatosNuc/FormEditResponse/DatosNucleo/DatNucleo/NumHijos" />",
            "TitularCabezaHogar": "<xsl:value-of select="DatosNuc/FormEditResponse/DatosNucleo/DatNucleo/TitularCabHogar" />",
            "TitularSabeLeerEscribir": "<xsl:value-of select="DatosNuc/FormEditResponse/DatosNucleo/DatNucleo/TitLeerEsc" />",
            "TipoDomicilio": ["<xsl:value-of select="TipoDomCli" />"]
            }
        </root>
    </xsl:template>
</xsl:stylesheet>
