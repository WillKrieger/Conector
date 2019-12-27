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
            <MontoActivos>
                <xsl:value-of select="Root/values/MontoActivos"/>
            </MontoActivos>
            <GastosMensuales>
                <xsl:value-of select="Root/values/GastosMensuales"/>
            </GastosMensuales>
            <Table>
                <FormEditResponse>
                    <xsl:for-each select="Root/values/Table">
                        <TableSprintReview>
                            <TabAccionista>
                                <NombreSocio>
                                    <xsl:apply-templates select="NombreSocio"/>
                                </NombreSocio>
                                <Participacion>
                                    <xsl:apply-templates select="Participacion"/>
                                </Participacion>
                                <TipoDocumentoDemo>
                                    <xsl:apply-templates select="TipoDocumento[1]"/>
                                </TipoDocumentoDemo>
                            </TabAccionista>
                        </TableSprintReview>
                    </xsl:for-each>
                </FormEditResponse>
            </Table>
        </root>
    </xsl:template>
</xsl:stylesheet>