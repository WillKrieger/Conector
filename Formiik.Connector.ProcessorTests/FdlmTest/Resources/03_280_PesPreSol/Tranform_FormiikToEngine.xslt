<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                exclude-result-prefixes="msxsl">
    <xsl:output method="text" indent="yes"/>
    <xsl:template match="root">
        <root>
            {
                "IdeDepExpDocIdeCli": ["<xsl:value-of select="IdeDepExpDocIdeCli"/>"],
                "FecExpDocIdeCli": "<xsl:value-of select="FecExpDocIdeCli"/>",
                "Cliente":
                    {
                        "FecNacCli":"<xsl:value-of select="FecNacCli"/>",
                        "GenCli":["<xsl:value-of select="GenCli"/>"],
                        "EstCivCli":["<xsl:value-of select="EstCivCli"/>"]
                    },
                "TieDisUniFam":"<xsl:value-of select="TieDisUniFam"/>",
                "CorEleCli":"<xsl:value-of select="CorEleCli"/>",
                "NomNeg":"<xsl:value-of select="NomNeg"/>",
                "FecCreNeg":"<xsl:value-of select="FecCreNeg"/>",
                "CanActCli":["<xsl:value-of select="CanActCli"/>"],
                "IdeSecEco1":["<xsl:value-of select="IdeSecEco1"/>", "<xsl:value-of select="IdeActEco1"/>"],
                "IdeSecEco2":["<xsl:value-of select="IdeSecEco2"/>", "<xsl:value-of select="IdeActEco2"/>"],
                "IdeSecEco3":["<xsl:value-of select="IdeSecEco3"/>", "<xsl:value-of select="IdeActEco3"/>"],
                "RelActAdiCli":"<xsl:value-of select="RelActAdiCli"/>",           
                "TipSol":["<xsl:value-of select="TipSol"/>", "<xsl:value-of select="ProSol"/>","<xsl:value-of select="DesCreSol"/>"],    
                "PotMas":"<xsl:value-of select="PotMas"/>",
                "PlaInvCre":
                    [
                        <xsl:for-each select="PlaInvCre/FormEditResponse/PlaInvCre">
                        {
                        "Cantidad": "<xsl:value-of select="PesPlaInv/CanPlaInv" />",
                        "Descripcion": "<xsl:value-of select="PesPlaInv/DesPlaInv" />",
                        "Valor": "<xsl:value-of select="PesPlaInv/ValPlaInv" />"
                        },
                    </xsl:for-each>
                    ], 
                "TotPlaInvCre":"<xsl:value-of select="TotPlaInvCre"/>",
                "MonSol":"<xsl:value-of select="MonSol"/>",
                "PlaSol":"<xsl:value-of select="PlaSol"/>",
                "PerSol":["<xsl:value-of select="PerSol"/>"],
                "ProCli":["<xsl:value-of select="OtrProCli"/>"],
                "OtrProCli":"<xsl:value-of select="PlaInvCre"/>",
                "MenResCreSol":"<xsl:value-of select="MenResCreSol"/>",
                "RutForpre":"<xsl:value-of select="RutForpre"/>",
                "ReqConSco":"<xsl:value-of select="ReqConSco"/>",
                "CauNegCreSol":["<xsl:value-of select="CauNegCreSol"/>"],
                "ComCauCreSol":["<xsl:value-of select="ComCauCreSol"/>"],
                "NumSolCre":"<xsl:value-of select="NumSolCre"/>",
                "CodCli":"<xsl:value-of select="CodCli"/>"
            }
        </root>
    </xsl:template>
</xsl:stylesheet>
