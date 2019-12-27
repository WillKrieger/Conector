<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                exclude-result-prefixes="msxsl">
    <xsl:output method="text" indent="yes"/>
    <xsl:template match="root">
        <root>
            {
                "RefFam":
                [
                    <xsl:for-each select="RefFam/FormEditResponse/Ref">
                    {
                        "Nombre": "<xsl:value-of select="PesRef/NomComRef"/>",
                        "Parentesco": ["<xsl:value-of select="PesRef/ParRef"/>"],
                        "Location": {
                            "Direccion": "<xsl:value-of select="PesRef/DirRef"/>"    
                        },
                        "Contact": {
                            "TelefonoLocal": "<xsl:value-of select="PesRef/TelRef"/>",
                            "TelefonoCelular": "<xsl:value-of select="PesRef/CelRef"/>"
                        },
                        "Ocupacion": "<xsl:value-of select="PesRef/OcuRef"/>",
                        "ActividadIndependiente": "<xsl:value-of select="PesRef/ActEcoInd"/>",
                        "Interesado": "<xsl:value-of select="PesRef/EstIntCreRef"/>",
                        "ProgramacionVisita": "<xsl:value-of select="PesRef/ProVisRef"/>",
                        "Observaciones": "<xsl:value-of select="PesRef/ObsRef"/>"
                    },
                </xsl:for-each>
                ],
                "CanRefFamCon": "<xsl:value-of select="CanRefFamCon"/>",
                "RefPer":
                [
                    <xsl:for-each select="RefPer/FormEditResponse/Ref">
                    {
                        "Nombre": "<xsl:value-of select="PesRef/NomComRef"/>",
                        "Parentesco": ["<xsl:value-of select="PesRef/ParRef"/>"],
                        "Location":{
                            "Direccion": "<xsl:value-of select="PesRef/DirRef"/>"
                        },
                        "Contact": {
                            "TelefonoLocal": "<xsl:value-of select="PesRef/TelRef"/>",
                            "TelefonoCelular": "<xsl:value-of select="PesRef/CelRef"/>"
                        },
                        "Ocupacion": "<xsl:value-of select="PesRef/OcuRef"/>",
                        "ActividadIndependiente": "<xsl:value-of select="PesRef/ActEcoInd"/>",
                        "Interesado": "<xsl:value-of select="PesRef/EstIntCreRef"/>",
                        "ProgramacionVisita": "<xsl:value-of select="PesRef/ProVisRef"/>",
                        "Observaciones": "<xsl:value-of select="PesRef/ObsRef"/>"
                    },
                </xsl:for-each>
                ],
                "RefComCli":
                [
                    <xsl:for-each select="RefComCli/FormEditResponse/RefCom">
                    {
                        "NombreEntidad": "<xsl:value-of select="PesRefCom/NomEmpRefCom"/>",
                        "Location": {
                            "Direccion": "<xsl:value-of select="PesRefCom/DirRefCom"/>",
                        },
                        "Contact": {
                            "TelefonoLocal": "<xsl:value-of select="PesRefCom/TelRefCom"/>",
                            "TelefonoCelular": "<xsl:value-of select="PesRefCom/CelRefCom"/>",
                        },
                        "ConfirmarRef": "<xsl:value-of select="PesRefCom/ConRefCom"/>",
                        "Antigüedad": "<xsl:value-of select="PesRefCom/AntRefCom"/>",
                        "Monto": "<xsl:value-of select="PesRefCom/MonRefCom"/>",
                        "FormaPago": ["<xsl:value-of select="PesRefCom/ForPagRefCom"/>"],
                        "Interesado": "<xsl:value-of select="PesRefCom/EstIntCreCom"/>",
                        "ProgramacionVisita": "<xsl:value-of select="PesRefCom/ProVisRefCom"/>",
                        "Observaciones": "<xsl:value-of select="PesRefCom/ObsRefCom"/>"
                    },
                </xsl:for-each>
                ],
                "CanRefComCon": "<xsl:value-of select="CanRefComCon"/>",
                "RefBanCli":
                [
                    <xsl:for-each select="RefBanCli/FormEditResponse/RefBanCli">
                    {
                        "EntidadBanco": ["<xsl:value-of select="PesRefBan/EntBanRefBan"/>"],
                        "Producto": ["<xsl:value-of select="PesRefBan/ProRefBan"/>"],
                        "Observaciones": "<xsl:value-of select="PesRefBan/ObsRefBan"/>"
                    },
                </xsl:for-each>
                ],
                "RefCli":
                [
                    <xsl:for-each select="RefCli/FormEditResponse/IngresoRecomendado">
                    {
                        "Subject": {
                            "Person": {
                                "PrimerNombre": "<xsl:value-of select="PesRef/PriNomRef"/>",
                                "SegundoNombre": "<xsl:value-of select="PesRef/SegNomRef"/>",
                                "PrimerApellido": "<xsl:value-of select="PesRef/PriApeRef"/>",
                                "SegundoApellido": "<xsl:value-of select="PesRef/SegApeRef"/>",
                                "Id":
                                {
                                    "TipoDocumento": ["<xsl:value-of select="PesRef/TipDocIdeRef"/>"],
                                    "NumeroDocCiudadania": "<xsl:value-of select="PesRef/NumDocIdeRef"/>",
                                    "PaisExpedicion": ["<xsl:value-of select="PesRef/PaiOriRef"/>"]
                                }
                            }
                        },
                        "Contact":{
                            "TelefonoLocal": "<xsl:value-of select="PesRef/TelRec"/>",
                            "TelefonoCelular": "<xsl:value-of select="PesRef/CelRec"/>",
                        },
                        "Location": {
                            "Direccion": "<xsl:value-of select="PesRef/DirNegRef"/>",    
                        },
                        "ActividadRecomendado": "<xsl:value-of select="PesRef/TieActRef"/>",
                        "IdeActNegRef": ["<xsl:value-of select="PesRef/ActividadSector"/>"],
                        "Origen": "<xsl:value-of select="PesRef/OriRecIngRec"/>",
                    },
                </xsl:for-each>
                ],
                 "Cod":
                [
                    <xsl:for-each select="Cod/FormEditResponse/Codeudor">
                    {
                        "Id":{
                            "TipoDocumento": ["<xsl:value-of select="PesDatBasCod/TipDocIdeCod"/>"],
                            "NumDocIdeCliCiudadania": "<xsl:value-of select="PesDatBasCod/NumDocIdeCod"/>",
                            "DepartamentoMunicipioBarrioExpedicion": ["<xsl:value-of select="PesDatPerCod/IdeDepExpDocIdeCod"/>", "<xsl:value-of select="PesDatPerCod/IdeMunExpDocIdeCod"/>"],
                            "PaisExpedicion": ["<xsl:value-of select="PesDatBasCod/PaiOriCod"/>"]
                        },
                        "TipoCodeudor": ["<xsl:value-of select="PesDatBasCod/TipCod"/>"],
                        "ClaseCodeudor": ["<xsl:value-of select="PesDatBasCod/ClaCod"/>"],
                        "Mensaje": "<xsl:value-of select="PesDatBasCod/MenResConCod"/>",
                        "CodigoRiesgo": "<xsl:value-of select="PesDatBasCod/CodRieValLisCod"/>",
                        "ListaControl": "<xsl:value-of select="PesDatBasCod/LisConValLisCod"/>",
                        "AdverteciaControl": "<xsl:value-of select="PesDatBasCod/AdvLisConCod"/>",
                        "Subject":{
                            "Person":{
                                "PrimerNombre": "<xsl:value-of select="PesDatBasCod/PriNomCod"/>",
                                "SegundoNombre": "<xsl:value-of select="PesDatBasCod/SegNomCod"/>",
                                "PrimerApellido": "<xsl:value-of select="PesDatBasCod/PriApeCod"/>",
                                "SegundoApellido": "<xsl:value-of select="PesDatBasCod/SegApeCod"/>",
                                "FechaNacimiento": "<xsl:value-of select="PesDatPerCod/FecNacCod"/>",
                                "Genero": ["<xsl:value-of select="PesDatPerCod/GenCod"/>"],
                                "EstadoCivil": ["<xsl:value-of select="PesDatPerCod/EstCivCod"/>"]
                            },
                            "Parentesco": ["<xsl:value-of select="PesDatPerCod/ParTitCod"/>"]
                        },
                        "Contact":{
                            "TelefonoLocal": "<xsl:value-of select="PesDatPerCod/TelCod"/>",    
                            "TelefonoCelular": "<xsl:value-of select="PesDatPerCod/CelCod"/>"
                        },
                        "DomicilioLocation":{
                            "Direccion": "<xsl:value-of select="PesDatPerCod/DirDomCod"/>",
                            "DepartamentoMunicipioBarrio": ["<xsl:value-of select="PesDatPerCod/IdeDepDomCod"/>", "<xsl:value-of select="PesDatPerCod/IdeMunDomCod"/>", "<xsl:value-of select="PesDatPerCod/IdeBarDomCod"/>"]
                        },
                        "ActividadOcupacion": "<xsl:value-of select="PesDatPerCod/ActOcuCod"/>",
                        "NombreConyuge": "<xsl:value-of select="PesDatPerCod/NomConCod"/>",
                        "TipoVivienda": ["<xsl:value-of select="PesDatPerCod/TipVivCod"/>"],
                        "Cual": "<xsl:value-of select="PesDatPerCod/CuaTipVivCod"/>",
                        "TiempoHabitada": "<xsl:value-of select="PesDatPerCod/TieHabVivCod"/>",
                        "Legalizado": "<xsl:value-of select="PesDatPerCod/EsLegVivCod"/>",
                        "PEP": "<xsl:value-of select="PesDatPerCod/CodFuePEP"/>",
                        "NombreArrendador": "<xsl:value-of select="PesDatPerCod/NomArrVivCod"/>",
                        "ContactArrendador":{
                            "TelefonoLocal": "<xsl:value-of select="PesDatPerCod/TelArrVivCod"/>",
                            "TelefonoCelular": "<xsl:value-of select="PesDatPerCod/CelArrVivCod"/>"
                        },
                        "ReferenciaCodeudor":{
                            "Nombre": "<xsl:value-of select="PesDatRefCod/NomComRefCod"/>",
                            "Parentesco": ["<xsl:value-of select="PesDatRefCod/ParRefCod"/>"],
                                "Location":{
                                "Direccion": "<xsl:value-of select="PesDatRefCod/DirRefCod"/>",
                                "DepartamentoMunicipioBarrio": ["<xsl:value-of select="PesDatRefCod/IdeDepRefCod"/>","<xsl:value-of select="PesDatRefCod/IdeMunRefCod"/>","<xsl:value-of select="PesDatRefCod/IdeBarRefCod"/>"]
                                },
                            "Contact":{
                                "TelefonoLocal": "<xsl:value-of select="PesDatRefCod/TelRefCod"/>",
                                "TelefonoCelular": "<xsl:value-of select="PesDatRefCod/CelRefCod"/>"
                                },
                            "Ocupacion": "<xsl:value-of select="PesDatRefCod/OcuRefCod"/>",
                            "ActividadIndependiente": "<xsl:value-of select="PesDatRefCod/ActEcoIndRef"/>",
                            "ActividadSector":["<xsl:value-of select="PesDatRefCod/IdeSecRefCod"/>","<xsl:value-of select="PesDatRefCod/IdeActRefCod"/>"],
                            "Interesado": "<xsl:value-of select="PesDatRefCod/EstIntCreRefCod"/>",
                            "ProgramacionVisita": "<xsl:value-of select="PesDatRefCod/ProVisRefCod"/>",
                            "Observaciones": "<xsl:value-of select="PesDatRefCod/ObsRefCod"/>"
                        },
                        "EsEmpleadoCodeudor": "<xsl:value-of select="PesDatLabNegCod/EstEmpCod"/>",
                        "CodeudorEmpleado":{
                            "Empresa": "<xsl:value-of select="PesDatLabNegCod/NomEmpLabCod"/>",
                            "Antigüedad": "<xsl:value-of select="PesDatLabNegCod/AntVinEmpCod"/>",
                            "Location":{
                                "Direccion": "<xsl:value-of select="PesDatLabNegCod/DirEmpCod"/>",
                                "DepartamentoMunicipioBarrio": ["<xsl:value-of select="PesDatLabNegCod/IdeDepEmpCod"/>","<xsl:value-of select="PesDatLabNegCod/IdeMunEmpCod"/>","<xsl:value-of select="PesDatLabNegCod/IdeBarEmpCod"/>"]
                            },
                            "CargoProfesion": "<xsl:value-of select="PesDatLabNegCod/CarEmpLabCod"/>",
                            "Salario": "<xsl:value-of select="PesDatLabNegCod/SalEmpLabCod"/>",
                            "ContactoLaboral": "<xsl:value-of select="PesDatLabNegCod/NomConEmpLabCod"/>",
                            "CargoContactoLaboral": "<xsl:value-of select="PesDatLabNegCod/CarConEmpLabCod"/>",
                            "TelefonoLaboral": "<xsl:value-of select="PesDatLabNegCod/TelConEmpLabCod"/>",
                            "ObservacionesLaboral": "<xsl:value-of select="PesDatLabNegCod/ObcConLab"/>",
                        },
                        "TieneNegocio": "<xsl:value-of select="PesDatLabNegCod/TieNegInd"/>",
                        "DatosNegocioCodeudor":{
                            "NombreRazonSocial": "<xsl:value-of select="PesDatLabNegCod/NomNegCod"/>",
                            "FechaInicio": "<xsl:value-of select="PesDatLabNegCod/FecCreNegCod"/>",
                            "NegoocioDomicilio":"<xsl:value-of select="PesDatLabNegCod/NegEnDomCod"/>",
                            "Location":{
                                "Direccion": "<xsl:value-of select="PesDatLabNegCod/DirNegCod"/>",
                                "Ubicacion": "<xsl:value-of select="PesDatLabNegCod/IndDirNegCod"/>",
                                "DepartamentoMunicipioBarrio": ["<xsl:value-of select="PesDatLabNegCod/IdeDepDomCod"/>","<xsl:value-of select="PesDatLabNegCod/IdeMunDomCod"/>","<xsl:value-of select="PesDatLabNegCod/IdeBarDomCod"/>"]
                            },
                            "Contact":{
                                "TelefonoLocal": "<xsl:value-of select="PesDatLabNegCod/TelNegCod"/>",
                                "TelefonoCelular": "<xsl:value-of select="PesDatLabNegCod/CelNegCod"/>"
                            },
                            "TipoLocal": ["<xsl:value-of select="PesDatLabNegCod/TipLocNegCod"/>"],
                            "ActividadSector":["<xsl:value-of select="PesDatLabNegCod/IdeSecNegCod"/>","<xsl:value-of select="PesDatLabNegCod/IdeActEcoCod"/>"],
                        },
                        "Ingresos": "<xsl:value-of select="PesDatLabNegCod/SecIngCod"/>",
                        "Ventas": "<xsl:value-of select="PesDatLabNegCod/VenCod"/>",
                        "TotalActivos": "<xsl:value-of select="PesDatLabNegCod/TotActCod"/>",
                        "Observaciones": "<xsl:value-of select="PesDatLabNegCod/ObsCod"/>",
                        "CantidadGarantias": "<xsl:value-of select="CanGarCod"/>",

                        "GarantiasCodeudor":{
                            "Cantidad": "<xsl:value-of select="PesGarCod/CanCod1"/>",
                            "Descripcion": "<xsl:value-of select="PesGarCod/DesBieCod1"/>",
                            "Valor": "<xsl:value-of select="PesGarCod/ValBieCod1"/>",
                        },
                        "GarantiasCodeudor2" : {
                            "Cantidad": "<xsl:value-of select="PesGarCod/CanCod2"/>",
                            "Descripcion": "<xsl:value-of select="PesGarCod/DesBieCod2"/>",
                            "Valor": "<xsl:value-of select="PesGarCod/ValBieCod2"/>",
                        },
                        "GarantiasCodeudor3" : {
                            "Cantidad": "<xsl:value-of select="PesGarCod/CanCod3"/>",
                            "Descripcion": "<xsl:value-of select="PesGarCod/DesBieCod3"/>",
                            "Valor": "<xsl:value-of select="PesGarCod/ValBieCod3"/>",
                        },
                        "GarantiasCodeudor4" : {
                            "Cantidad": "<xsl:value-of select="PesGarCod/CanCod4"/>",
                            "Descripcion": "<xsl:value-of select="PesGarCod/DesBieCod4"/>",
                            "Valor": "<xsl:value-of select="PesGarCod/ValBieCod4"/>",
                        },
                        "GarantiasCodeudor5" : {
                            "Cantidad": "<xsl:value-of select="PesGarCod/CanCod5"/>",
                            "Descripcion": "<xsl:value-of select="PesGarCod/DesBieCod5"/>",
                            "Valor": "<xsl:value-of select="PesGarCod/ValBieCod5"/>",
                        },
                        "GarantiasCodeudor6" : {
                                "Cantidad": "<xsl:value-of select="PesGarCod/CanCod6"/>",
                                "Descripcion": "<xsl:value-of select="PesGarCod/DesBieCod6"/>",
                                "Valor": "<xsl:value-of select="PesGarCod/ValBieCod6"/>",
                        },
                        "GarantiasCodeudor7" : {
                            "Cantidad": "<xsl:value-of select="PesGarCod/CanCod7"/>",
                            "Descripcion": "<xsl:value-of select="PesGarCod/DesBieCod7"/>",
                            "Valor": "<xsl:value-of select="PesGarCod/ValBieCod7"/>",
                        },
                        "GarantiasCodeudor8" : {
                            "Cantidad": "<xsl:value-of select="PesGarCod/CanCod8"/>",
                            "Descripcion": "<xsl:value-of select="PesGarCod/DesBieCod8"/>",
                            "Valor": "<xsl:value-of select="PesGarCod/ValBieCod8"/>",
                        },
                        "GarantiasCodeudor9" : {
                            "Cantidad": "<xsl:value-of select="PesGarCod/CanCod9"/>",
                            "Descripcion": "<xsl:value-of select="PesGarCod/DesBieCod9"/>",
                            "Valor": "<xsl:value-of select="PesGarCod/ValBieCod9"/>",
                        },
                        "GarantiasCodeudor10" : {
                              "Cantidad": "<xsl:value-of select="PesGarCod/CanCod10"/>",
                              "Descripcion": "<xsl:value-of select="PesGarCod/DesBieCod10"/>",
                              "Valor": "<xsl:value-of select="PesGarCod/ValBieCod10"/>",
                        
                        }
                    },
                </xsl:for-each>
                ],
                "CanCodCom": "<xsl:value-of select="CanCodCom"/>",
                "CanKnoOutCod": "<xsl:value-of select="CanKnoOutCod"/>",
                "ValTotGarCod": "<xsl:value-of select="ValTotGarCod"/>",
                "TipGarCre": ["<xsl:value-of select="TipGarCre"/>"],
                "GarCli":
                [
                    <xsl:for-each select="GarCli/FormEditResponse/Garantia">
                    {
                        "TipoGarantia": ["<xsl:value-of select="PesGar/TipGar"/>"],
                        "Cantidad": "<xsl:value-of select="PesGar/Can"/>",
                        "Descripcion": "<xsl:value-of select="PesGar/DesBie"/>",
                        "Valor": "<xsl:value-of select="PesGar/ValBie"/>"
                    },
                </xsl:for-each>
                ],
                "Ppi7_HogTieLav": "<xsl:value-of select="Ppi7_HogTieLav"/>",
                "Ppi8_HogTieHorMic": "<xsl:value-of select="Ppi8_HogTieHorMic"/>",
                "Ppi9_HogTieCarPar": "<xsl:value-of select="Ppi9_HogTieCarPar"/>",
                "TitConPosSma": "<xsl:value-of select="TitConPosSma"/>",
                "Fot1GarCli": "<xsl:value-of select="Fot1GarCli"/>",
                "Fot2GarCli": "<xsl:value-of select="Fot2GarCli"/>",
                "Fot1GarCliSolCor": "<xsl:value-of select="Fot1GarCliSolCor"/>",
                "Fot2GarCliSolCor": "<xsl:value-of select="Fot2GarCliSolCor"/>"
            }
        </root>
    </xsl:template>
</xsl:stylesheet>
