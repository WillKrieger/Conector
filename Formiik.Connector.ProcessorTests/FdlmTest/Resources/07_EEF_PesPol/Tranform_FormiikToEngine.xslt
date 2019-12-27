<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                exclude-result-prefixes="msxsl">
    <xsl:output method="text" indent="yes"/>
    <xsl:template match="root">
        <root>
            {
                "DesAdqPolTuHijSeg": "<xsl:value-of select="DesAdqPolTuHijSeg"/>",
                "ParBenTuHijSeg": ["<xsl:value-of select="ParBenTuHijSeg"/>"],
                "BenPolTuHijSeg":
                [
                    <xsl:for-each select="BenPolTuHijSeg/FormEditResponse/BenTuHijSeg">
                    {
                        "Subject":{
                            "Person":{
                                "PrimerNombre": "<xsl:value-of select="PesBenTuHij/NomBenTuHij"/>",
                                "PrimerApellido": "<xsl:value-of select="PesBenTuHij/PriApeBenTuHij"/>",
                                "SegundoApellido": "<xsl:value-of select="PesBenTuHij/SegApeBenTuHij"/>"
                            }
                        }
                    },
                </xsl:for-each>
                ],
                "CanBenPolTuHijSeg": "<xsl:value-of select="CanBenPolTuHijSeg"/>",
                "DesAdqPlaPreExe": "<xsl:value-of select="DesAdqPlaPreExe"/>",
                "TraEntExe": "<xsl:value-of select="TraEntExe"/>",
                "AfiAdiPolExe":
                [
                    <xsl:for-each select="AfiAdiPolExe/FormEditResponse/AfiExeAdi">
                    {
                        "Subject":{
                            "Person":{
                                "Id":{
                                    "TipoDocumento": ["<xsl:value-of select="PesAfiAdi/TipDocIdeBen"/>"],
                                    "NumeroDocCiudadania": "<xsl:value-of select="PesAfiAdi/NumDocIdeBen"/>"
                                },
                                "PrimerNombre": "<xsl:value-of select="PesAfiAdi/NomBen"/>",
                                "PrimerApellido": "<xsl:value-of select="PesAfiAdi/PriApeBen"/>",
                                "SegundoApellido": "<xsl:value-of select="PesAfiAdi/SegApeBen"/>",
                                "FechaNacimiento": "<xsl:value-of select="PesAfiAdi/FecNacBen"/>",
                                "Genero": ["<xsl:value-of select="PesAfiAdi/GenBen"/>"]
                            },
                            "Parentesco": ["<xsl:value-of select="PesAfiAdi/ParBen"/>"]
                        }
                    },
                </xsl:for-each>
                ],
                "CanAfiAdiPolExe": "<xsl:value-of select="CanAfiAdiPolExe"/>",
                "BenAuxInmPolExe":
                [
                    <xsl:for-each select="BenAuxInmPolExe/FormEditResponse/BenExeAuxInm">
                    {   
                        "Subject":{
                            "Person":{
                                "Id":{
                                    "TipoDocumento": ["<xsl:value-of select="PesBenAuxInm/TipDocIdeBenAuxInm"/>"],
                                    "NumeroDocCiudadania": "<xsl:value-of select="PesBenAuxInm/NumDocIdeBenAuxInm"/>"
                                },
                                "PrimerNombre": "<xsl:value-of select="PesBenAuxInm/NomBenAuxInm"/>",
                                "PrimerApellido": "<xsl:value-of select="PesBenAuxInm/PriApeBenAuxInm"/>",
                                "SegundoApellido": "<xsl:value-of select="PesBenAuxInm/SegApeBenAuxInm"/>"
                            },
                            "Parentesco": ["<xsl:value-of select="PesBenAuxInm/ParBenAuxInm"/>"]  
                        }
                    },
                </xsl:for-each>
                ],
                "DesAdqPolVid": "<xsl:value-of select="DesAdqPolVid"/>",
                "DecNoPadEnfCroPolVid": "<xsl:value-of select="DecNoPadEnfCroPolVid"/>",
                "PlaTitPolVid": ["<xsl:value-of select="PlaTitPolVid"/>"],
                "BenTitPolVid":
                [
                    <xsl:for-each select="BenTitPolVid/FormEditResponse/BenVid">
                    {
                        "Subject":{
                            "Person":{
                                "PrimerNombre": "<xsl:value-of select="PesBenVid/NomBenVid"/>",
                                "PrimerApellido": "<xsl:value-of select="PesBenVid/PriApeBenVid"/>",
                                "SegundoApellido": "<xsl:value-of select="PesBenVid/SegApeBenVid"/>"
                            },
                            "Parentesco": ["<xsl:value-of select="PesBenVid/ParBenVid"/>"]
                        },
                        "Porcentaje": "<xsl:value-of select="PesBenVid/PorBenVid"/>"
                    },
                </xsl:for-each>
                ],
                "SumPorTitPolVid": "<xsl:value-of select="SumPorTitPolVid"/>",
                "DesPolCon": "<xsl:value-of select="DesPolCon"/>",
                "PlaConPolVid": ["<xsl:value-of select="PlaConPolVid"/>"],
                "BenConPolVid":
                [
                    <xsl:for-each select="BenConPolVid/FormEditResponse/BenVid">
                    {
                        "Subject":{
                            "Person":{
                                "PrimerNombre": "<xsl:value-of select="PesBenVid/NomBenVid"/>",
                                "PrimerApellido": "<xsl:value-of select="PesBenVid/PriApeBenVid"/>",
                                "SegundoApellido": "<xsl:value-of select="PesBenVid/SegApeBenVid"/>"
                            },
                            "Parentesco": ["<xsl:value-of select="PesBenVid/ParBenVid"/>"]
                        },
                        "Porcentaje": "<xsl:value-of select="PesBenVid/PorBenVid"/>"
                    },
                </xsl:for-each>
                ],
                "SumPorConPolVid": "<xsl:value-of select="SumPorConPolVid"/>",
                "SecPolDan": "<xsl:value-of select="SecPolDan"/>",
                "Ppi10_MatPrePisViv": ["<xsl:value-of select="Ppi10_MatPrePisViv"/>"],
                "DesAdqPolDan": "<xsl:value-of select="DesAdqPolDan"/>",
                "RieAsePolDan": ["<xsl:value-of select="RieAsePolDan"/>"],
                "TipConPolDan": ["<xsl:value-of select="TipConPolDan"/>"],
                "DesAseEdi": "<xsl:value-of select="DesAseEdi"/>",
                "PlaCobEdi": ["<xsl:value-of select="PlaCobEdi"/>"],
                "DesAseCon": "<xsl:value-of select="DesAseCon"/>",
                "PlaCobCon": ["<xsl:value-of select="PlaCobCon"/>"],
                "DesAseSub": "<xsl:value-of select="DesAseSub"/>",
                "PlaConSub": ["<xsl:value-of select="PlaConSub"/>"],
                "DesAgrRieAdi": "<xsl:value-of select="DesAgrRieAdi"/>",
                "RieAsePolDanAdi": ["<xsl:value-of select="RieAsePolDanAdi"/>"],
                "TipConPolDanAdi": ["<xsl:value-of select="TipConPolDanAdi"/>"],
                "DesAseEdiAdi": "<xsl:value-of select="DesAseEdiAdi"/>",
                "PlaCobEdiAdi": ["<xsl:value-of select="PlaCobEdiAdi"/>"],
                "DesAseConAdi": "<xsl:value-of select="DesAseConAdi"/>",
                "PlaCobConAdi": ["<xsl:value-of select="PlaCobConAdi"/>"],
                "DesAseSubAdi": "<xsl:value-of select="DesAseSubAdi"/>",
                "PlaConSubAdi": "<xsl:value-of select="PlaConSubAdi"/>",
                "UniFamSegExt": "<xsl:value-of select="UniFamSegExt"/>",
                "TipSegUniFam": "<xsl:value-of select="TipSegUniFam"/>"
            }
        </root>
    </xsl:template>
</xsl:stylesheet>
