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
            <CliRelCueCob>
                <xsl:value-of select="Root/values/CliRelCueCob"/>
            </CliRelCueCob>
            <NumCliCueCob>
                <xsl:value-of select="Root/values/NumCliCueCob"/>
            </NumCliCueCob>
            <ObsCuePorCob>
                <xsl:value-of select="Root/values/ObsCuePorCob"/>
            </ObsCuePorCob>
            <MonCuePorCob>
                <xsl:value-of select="Root/values/MonCuePorCob"/>
            </MonCuePorCob>
            <IncCueCob>
                <xsl:value-of select="Root/values/IncCueCob"/>
            </IncCueCob>
            <TotCuePorCob>
                <xsl:value-of select="Root/values/TotCuePorCob"/>
            </TotCuePorCob>
            <InvMer>
                <FormEditResponse>
                    <xsl:for-each select="Root/values/InvMer">
                        <InvMer>
                            <InvMerMarPri>
                                <Can>
                                    <xsl:apply-templates select="Can"/>
                                </Can>
                                <Uni>
                                    <xsl:apply-templates select="Uni"/>
                                </Uni>
                                <DesInv>
                                    <xsl:apply-templates select="DesInv"/>
                                </DesInv>
                                <PreComUni>
                                    <xsl:apply-templates select="PreComUni"/>
                                </PreComUni>
                                <PreVenUni>
                                    <xsl:apply-templates select="PreVenUni"/>
                                </PreVenUni>
                                <MarUti>
                                    <xsl:apply-templates select="MarUti"/>
                                </MarUti>
                                <ValTot>
                                    <xsl:apply-templates select="ValTo"/>
                                </ValTot>
                            </InvMerMarPri>
                        </InvMer>
                    </xsl:for-each>
                </FormEditResponse>
            </InvMer>
            <InvMatPri1>
                <FormEditResponse>
                    <xsl:for-each select="Root/values/InvMatPri1">
                        <InvMatPri1>
                            <InvMerMarPri>
                                <Can>
                                    <xsl:apply-templates select="Can"/>
                                </Can>
                                <Uni>
                                    <xsl:apply-templates select="Uni"/>
                                </Uni>
                                <DesInv>
                                    <xsl:apply-templates select="DesInv"/>
                                </DesInv>
                                <PreComUni>
                                    <xsl:apply-templates select="PreComUni"/>
                                </PreComUni>
                                <PreVenUni>
                                    <xsl:apply-templates select="PreVenUni"/>
                                </PreVenUni>
                                <MarUti>
                                    <xsl:apply-templates select="MarUti"/>
                                </MarUti>
                                <ValTot>
                                    <xsl:apply-templates select="ValTo"/>
                                </ValTot>
                            </InvMerMarPri>
                        </InvMatPri1>
                    </xsl:for-each>
                </FormEditResponse>
            </InvMatPri1>
            <InvPtoPro1>
                <FormEditResponse>
                    <xsl:for-each select="Root/values/InvPtoPro1">
                        <InvPtoPro1>
                            <InvMerMarPri>
                                <Can>
                                    <xsl:apply-templates select="Can"/>
                                </Can>
                                <Uni>
                                    <xsl:apply-templates select="Uni"/>
                                </Uni>
                                <DesInv>
                                    <xsl:apply-templates select="DesInv"/>
                                </DesInv>
                                <PreComUni>
                                    <xsl:apply-templates select="CosUni"/>
                                </PreComUni>
                                <PreVenUni>
                                    <xsl:apply-templates select="CosEstUni"/>
                                </PreVenUni>
                                <ValTot>
                                    <xsl:apply-templates select="ValTo"/>
                                </ValTot>
                            </InvMerMarPri>
                        </InvPtoPro1>
                    </xsl:for-each>
                </FormEditResponse>
            </InvPtoPro1>
            <InvPtoTer1>
                <FormEditResponse>
                    <xsl:for-each select="Root/values/InvPtoTer1">
                        <InvPtoTer1>
                            <InvMerMarPri>
                                <Can>
                                    <xsl:apply-templates select="Can"/>
                                </Can>
                                <Uni>
                                    <xsl:apply-templates select="Uni"/>
                                </Uni>
                                <DesInv>
                                    <xsl:apply-templates select="DesInv"/>
                                </DesInv>
                                <PreComUni>
                                    <xsl:apply-templates select="PreComUni"/>
                                </PreComUni>
                                <PreVenUni>
                                    <xsl:apply-templates select="PreVenUni"/>
                                </PreVenUni>
                                <MarUti>
                                    <xsl:apply-templates select="MarUti"/>
                                </MarUti>
                                <ValTot>
                                    <xsl:apply-templates select="ValTo"/>
                                </ValTot>
                            </InvMerMarPri>
                        </InvPtoTer1>
                    </xsl:for-each>
                </FormEditResponse>
            </InvPtoTer1>
            <TotInv>
                <xsl:value-of select="Root/values/TotInv"/>
            </TotInv>
            <ComActFijNeg>
                <FormEditResponse>
                    <xsl:for-each select="Root/values/ComActFijNeg">
                        <ComActFijNeg>
                            <ActFij1>
                                <CanActFij>
                                    <xsl:apply-templates select="Cantidad"/>
                                </CanActFij>
                                <DesActFij>
                                    <xsl:apply-templates select="Descripcion"/>
                                </DesActFij>
                                <ValUniActFij>
                                    <xsl:apply-templates select="ValorUnitario"/>
                                </ValUniActFij>
                                <ValActFij>
                                    <xsl:apply-templates select="ValorTotal"/>
                                </ValActFij>
                            </ActFij1>
                        </ComActFijNeg>
                    </xsl:for-each>
                </FormEditResponse>
            </ComActFijNeg>
            <ComActFijFam>
                <FormEditResponse>
                    <xsl:for-each select="Root/values/ComActFijFam">
                        <ComActFijFam>
                            <ActFij1>
                                <CanActFij>
                                    <xsl:apply-templates select="Cantidad"/>
                                </CanActFij>
                                <DesActFij>
                                    <xsl:apply-templates select="Descripcion"/>
                                </DesActFij>
                                <ValUniActFij>
                                    <xsl:apply-templates select="ValorUnitario"/>
                                </ValUniActFij>
                                <ValActFij>
                                    <xsl:apply-templates select="ValorTotal"/>
                                </ValActFij>
                            </ActFij1>
                        </ComActFijFam>
                    </xsl:for-each>
                </FormEditResponse>
            </ComActFijFam>
            <FotNegCli>
                <xsl:value-of select="Root/values/FotNegCli"/>
            </FotNegCli>
            <FotNegCliSolCor>
                <xsl:value-of select="Root/values/FotNegCliSolCor"/>
            </FotNegCliSolCor>
        </root>
    </xsl:template>
</xsl:stylesheet>