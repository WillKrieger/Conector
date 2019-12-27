<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
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
            <MontoRec><xsl:value-of select="Root/values/MontoRecomendado"/></MontoRec>
            <NumCuotas><xsl:value-of select="Root/values/NumeroCuotasRecomendado"/></NumCuotas>
            <ValCuotas><xsl:value-of select="Root/values/ValorCuotasRecomendado"/></ValCuotas>
            <PeriodFormPago><xsl:value-of select="Root/values/FormaPagoRecomendado"/></PeriodFormPago>
        </root>
    </xsl:template>
</xsl:stylesheet>