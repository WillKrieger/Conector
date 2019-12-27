<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output indent="yes" method="xml"/>
    <xsl:template match="/">
        <root>
            <Calle/>
            <Colonia/>
            <CodigoPostal/>
            <Estado/>
            <Municipio/>
            <Ciudad/>
            <Nombre>
                <xsl:value-of select="Root/values/Nombre"/>
            </Nombre>
            <PrimerApellido>
                <xsl:value-of select="Root/values/PrimerApellido"/>
            </PrimerApellido>
            <SegundoApellido>
                <xsl:value-of select="Root/values/SegundoApellido"/>
            </SegundoApellido>
            <FechaNacimiento>
                <xsl:value-of select="Root/values/FechaNacimiento"/>
            </FechaNacimiento>
            <EstadoCivil>
                <xsl:value-of select="Root/values/EstadoCivil"/>
            </EstadoCivil>
            <CalleYNumero>
                <xsl:value-of select="Root/values/LocalizacionDomicilioTitular/CalleYNumero"/>
            </CalleYNumero>
            <DeptoMunicipioBarrioDomicilio0ID>
                <xsl:value-of select="Root/values/LocalizacionDomicilioTitular/DeptoMunicipioBarrioDomicilio[3]"/>
            </DeptoMunicipioBarrioDomicilio0ID>
            <DeptoMunicipioBarrioDomicilio1ID>
                <xsl:value-of select="Root/values/LocalizacionDomicilioTitular/DeptoMunicipioBarrioDomicilio[2]"/>
            </DeptoMunicipioBarrioDomicilio1ID>
            <DeptoMunicipioBarrioDomicilio2ID>
                <xsl:value-of select="Root/values/LocalizacionDomicilioTitular/DeptoMunicipioBarrioDomicilio[1]"/>
            </DeptoMunicipioBarrioDomicilio2ID>
            <Zona>
                <xsl:value-of select="Root/values/Zona"/>
            </Zona>
        </root>
    </xsl:template>
</xsl:stylesheet>