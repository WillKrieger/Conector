<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output indent="yes" method="xml"/>
    <xsl:template match="/">
        <root>
            <Nombre/>
            <Calle/>
            <Colonia/>
            <CodigoPostal/>
            <Estado/>
            <Municipio/>
            <Ciudad/>
            <xsl:if test = "Root/values/ResAprDatCre = 'true'">
                <ValidacionAprobada><xsl:text>Si</xsl:text></ValidacionAprobada>
            </xsl:if>
            <xsl:if test = "Root/values/ResAprDatCre = 'false'">
                <ValidacionAprobada><xsl:text>No</xsl:text></ValidacionAprobada>
            </xsl:if>

            <xsl:if test = "Root/values/EsCliExc = 'true'">
                <ClienteExclusivo><xsl:text>Si</xsl:text></ClienteExclusivo>
            </xsl:if>
            <xsl:if test = "Root/values/EsCliExc = 'false'">
                <ClienteExclusivo><xsl:text>No</xsl:text></ClienteExclusivo>
            </xsl:if>
            <ObservacionesComportamientoPago>
                <xsl:value-of select="Root/values/ObsCliExc"/>
            </ObservacionesComportamientoPago>
        </root>
    </xsl:template>
</xsl:stylesheet>