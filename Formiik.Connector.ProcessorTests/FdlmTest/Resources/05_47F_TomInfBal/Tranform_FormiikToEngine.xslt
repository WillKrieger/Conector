<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                exclude-result-prefixes="msxsl">
    <xsl:output method="text" indent="yes"/>
    <xsl:template match="root">
        <root>
            {
                "CliRelCueCob": "<xsl:value-of select="CliRelCueCob"/>",
                "NumCliCueCob": "<xsl:value-of select="NumCliCueCob"/>",
                "ObsCuePorCob": "<xsl:value-of select="ObsCuePorCob"/>",
                "MonCuePorCob": "<xsl:value-of select="MonCuePorCob"/>",
                "IncCueCob": "<xsl:value-of select="IncCueCob"/>",
                "TotCuePorCob": "<xsl:value-of select="TotCuePorCob"/>",
                "InvMer":
                [
                    <xsl:for-each select="InvMer/FormEditResponse/InvPtoPro1">
                    {
                        "Can": "<xsl:value-of select="InvMerMarPri/Can"/>",
                        "Uni": "<xsl:value-of select="InvMerMarPri/Uni"/>",
                        "DesInv": "<xsl:value-of select="InvMerMarPri/DesInv"/>",
                        "PreComUni": "<xsl:value-of select="InvMerMarPri/PreComUni"/>",
                        "PreVenUni": "<xsl:value-of select="InvMerMarPri/PreVenUni"/>",
                        "MarUti": "<xsl:value-of select="InvMerMarPri/MarUti"/>",
                        "ValTo": "<xsl:value-of select="InvMerMarPri/ValTot "/>"
                    },
                    </xsl:for-each>
                ],
                "InvMatPri1":
                [
                    <xsl:for-each select="InvMatPri1/FormEditResponse/Inventarios">
                    {
                        "Can": "<xsl:value-of select="InvMerMarPri/Can"/>",
                        "Uni": "<xsl:value-of select="InvMerMarPri/Uni"/>",
                        "DesInv": "<xsl:value-of select="InvMerMarPri/DesInv"/>",
                        "PreComUni": "<xsl:value-of select="InvMerMarPri/PreComUni"/>",
                        "PreVenUni": "<xsl:value-of select="InvMerMarPri/PreVenUni"/>",
                        "MarUti": "<xsl:value-of select="InvMerMarPri/MarUti"/>",
                        "ValTo": "<xsl:value-of select="InvMerMarPri/ValTot "/>"
                    },
                </xsl:for-each>
                ],
                "InvPtoPro1":
                [
                    <xsl:for-each select="InvPtoPro1/FormEditResponse/ProdProc">
                    {
                        "InvPtoPro1":{
                            "Can": "<xsl:value-of select="InvMerMarPri/Can"/>",
                            "Uni": "<xsl:value-of select="InvMerMarPri/Uni"/>",
                            "DesInv": "<xsl:value-of select="InvMerMarPri/DesInv"/>",
                            "CosUni": "<xsl:value-of select="InvMerMarPri/PreComUni"/>",
                            "CosEstUni": "<xsl:value-of select="InvMerMarPri/PreVenUni"/>",
                            "ValTo": "<xsl:value-of select="InvMerMarPri/ValTot "/>"
                        }
                    },
                </xsl:for-each>
                ],
                "InvPtoTer1":
                [
                    <xsl:for-each select="InvPtoTer1/FormEditResponse/Inventarios">
                    {
                        "Can": "<xsl:value-of select="InvMerMarPri/Can"/>",
                        "Uni": "<xsl:value-of select="InvMerMarPri/Uni"/>",
                        "DesInv": "<xsl:value-of select="InvMerMarPri/DesInv"/>",
                        "PreComUni": "<xsl:value-of select="InvMerMarPri/PreComUni"/>",
                        "PreVenUni": "<xsl:value-of select="InvMerMarPri/PreVenUni"/>",
                        "MarUti": "<xsl:value-of select="InvMerMarPri/MarUti"/>",
                        "ValTo": "<xsl:value-of select="InvMerMarPri/ValTot "/>"
                    },
                </xsl:for-each>
                ],
                "TotInv": "<xsl:value-of select="TotInv"/>",
                "ComActFij": "<xsl:value-of select="ComActFij"/>",
                "ComActFijNeg":
                [
                    <xsl:for-each select="ComActFijNeg/FormEditResponse/Activos">
                    {
                        "Cantidad": "<xsl:value-of select="ActFij1/CanActFij"/>",
                        "Descripcion": "<xsl:value-of select="ActFij1/DesActFij"/>",
                        "ValorUnitario": "<xsl:value-of select="ActFij1/ValUniActFij"/>",
                        "ValorTotal": "<xsl:value-of select="ActFij1/ValActFij "/>"
                    },
                </xsl:for-each>
                ],
                "ComActFijFam":
                [
                    <xsl:for-each select="ComActFijFam/FormEditResponse/Activos">
                    {
                        "Cantidad": "<xsl:value-of select="ActFij1/CanActFij"/>",
                        "Descripcion": "<xsl:value-of select="ActFij1/DesActFij"/>",
                        "ValorUnitario": "<xsl:value-of select="ActFij1/ValUniActFij"/>",
                        "ValorTotal": "<xsl:value-of select="ActFij1/ValActFij"/>"
                    },
                </xsl:for-each>
                ],
                "FotNegCli": "<xsl:value-of select="FotNegCli"/>",
                "FotNegCliSolCor": "<xsl:value-of select="FotNegCliSolCor"/>"
            }
        </root>
    </xsl:template>
</xsl:stylesheet>
