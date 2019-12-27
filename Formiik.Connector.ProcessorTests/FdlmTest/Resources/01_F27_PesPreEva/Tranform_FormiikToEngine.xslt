<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                exclude-result-prefixes="msxsl">
    <xsl:output method="text" indent="yes"/>
    <xsl:template match="root">
        <root>
            {
                "VisAyu": "<xsl:value-of select="VisAyu"/>",
                "Identificacion":
                {
                    "TipDocIdeCli":["<xsl:value-of select="TipDocIdeCli"/>"],
                    "NumDocIdeCliCiudadania":"<xsl:value-of select="NumDocIdeCli"/>",
                    "PaiExpCli":["<xsl:value-of select="PaiExpCli"/>"]
                },
                "NumSolCre":"<xsl:value-of select="NumSolCre"/>",
                "DesCarInfCli":"<xsl:value-of select="DesCarInfCli"/>",
                "MenResConCliSol":"<xsl:value-of select="MenResConCliSol"/>",
                "CodRieValLisConCli":"<xsl:value-of select="CodRieValLisConCli"/>",
                "LisConValLisConCli":"<xsl:value-of select="LisConValLisConCli"/>",
                "AdvLisConCli":"<xsl:value-of select="AdvLisConCli"/>",
                "CalCli":"<xsl:value-of select="CalCli"/>",
                "Titular":{
                        "PriNomCli":"<xsl:value-of select="PriNomCli"/>",
                        "SegNomCli":"<xsl:value-of select="SegNomCli"/>",
                        "PriApeCli":"<xsl:value-of select="PriApeCli"/>",
                        "SegApeCli":"<xsl:value-of select="SegApeCli "/>",
                },
                "RutForUltCre":"<xsl:value-of select="RutForUltCre"/>",
                "CelPerCli":"<xsl:value-of select="CelPerCli"/>",
                "TelNegCli":"<xsl:value-of select="TelNegCli"/>",
                "CelNegCli":"<xsl:value-of select="CelNegCli"/>",
                "NegEnDom":"<xsl:value-of select="NegEnDom"/>",
                "LocalizacionDomicilioTitular":{
                    "DirDomCli":"<xsl:value-of select="DirDomCli"/>",
                    "DeptoMunicipioBarrioDomicilio":["<xsl:value-of select="IdeDepBarDomCli"/>", "<xsl:value-of select="IdeMunBarDomCli"/>", "<xsl:value-of select="IdeBarDomCli"/>"],
                    "IndDirDomCli":"<xsl:value-of select="IndDirDomCli"/>",
                    "UbiDomCli":{
                        "Latitud":"<xsl:value-of select="UbiDomCli/root/gpsLat"/>",
                        "Longitud":"<xsl:value-of select="UbiDomCli/root/gpsLng"/>"
                    }
                },
                "TipNeg":["<xsl:value-of select="TipNeg"/>"],
                "LocalizacionNegocioTitular":{
                    "DirNegCli":"<xsl:value-of select="DirNegCli"/>",
                    "DeptoMunicipioBarrioNegocio":["<xsl:value-of select="IdeDepBarNegCli"/>","<xsl:value-of select="IdeMunBarNegCli"/>", "<xsl:value-of select="IdeBarNegCli"/>"],
                    "IndDirNegCli":"<xsl:value-of select="IndDirNegCli"/>"
                },
                "LocalizacionNegocioTitular":{
                    "UbiNegCli":{
                    "Latitud":"<xsl:value-of select="UbiNegCli/root/gpsLat"/>",
                    "Longitud":"<xsl:value-of select="UbiNegCli/root/gpsLng"/>"
                    }
                },
                "HaPadSigEnf":"<xsl:value-of select="HaPadSigEnf"/>",
                "HaPadLimFis":"<xsl:value-of select="HaPadLimFis"/>",
                "CumReqMin":"<xsl:value-of select="CumReqMin"/>",
                "CauDenPreEva":["<xsl:value-of select="CauDenPreEva"/>"],
                "ComCauDenPreEva":"<xsl:value-of select="ComCauDenPreEva"/>",
                "LleSolOtroMom":"<xsl:value-of select="LleSolOtroMom"/>",
                "FecProVis":"<xsl:value-of select="FecProVis"/>"
            }
        </root>
    </xsl:template>
</xsl:stylesheet>
