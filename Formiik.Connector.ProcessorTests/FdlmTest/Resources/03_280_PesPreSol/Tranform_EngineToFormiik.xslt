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
            <IdeDepExpDocIdeCli>
                <xsl:value-of select="Root/values/IdeDepExpDocIdeCli"/>
            </IdeDepExpDocIdeCli>
            <FecExpDocIdeCli>
                <xsl:value-of select="Root/values/FecExpDocIdeCli"/>
            </FecExpDocIdeCli>
            <FecNacCli>
                <xsl:value-of select="Root/values/Cliente/FecNacCli"/>
            </FecNacCli>
            <GenCli>
                <xsl:value-of select="Root/values/Cliente/GenCli"/>
            </GenCli>
            <EstCivCli>
                <xsl:value-of select="Root/values/Cliente/EstCivCli"/>
            </EstCivCli>
            <TieDisUniFam>
                <xsl:value-of select="Root/values/TieDisUniFam"/>
            </TieDisUniFam>
            <CorEleCli>
                <xsl:value-of select="Root/values/CorEleCli"/>
            </CorEleCli>
            <NomNeg>
                <xsl:value-of select="Root/values/NomNeg"/>
            </NomNeg>
            <FecCreNeg>
                <xsl:value-of select="Root/values/FecCreNeg"/>
            </FecCreNeg>
            <CanActCli>
                <xsl:value-of select="Root/values/CanActCli"/>
            </CanActCli>
            <IdeSecEco1>
                <xsl:value-of select="Root/values/IdeSecEco1[1]"/>
            </IdeSecEco1>
            <IdeActEco1>
                <xsl:value-of select="Root/values/IdeSecEco1[2]"/>
            </IdeActEco1>
            <IdeSecEco2>
                <xsl:value-of select="Root/values/IdeSecEco2[1]"/>
            </IdeSecEco2>
            <IdeActEco2>
                <xsl:value-of select="Root/values/IdeSecEco2[2]"/>
            </IdeActEco2>
            <IdeSecEco3>
                <xsl:value-of select="Root/values/IdeSecEco3[1]"/>
            </IdeSecEco3>
            <IdeActEco3>
                <xsl:value-of select="Root/values/IdeSecEco3[2]"/>
            </IdeActEco3>
            <RelActAdiCli>
                <xsl:value-of select="Root/values/RelActAdiCli"/>
            </RelActAdiCli>
            <TipSol>
                <xsl:value-of select="Root/values/TipSol[1]"/>
            </TipSol>
            <ProSol>
                <xsl:value-of select="Root/values/TipSol[2]"/>
            </ProSol>
            <DesCreSol>
                <xsl:value-of select="Root/values/TipSol[3]"/>
            </DesCreSol>
            <PotMas>
                <xsl:value-of select="Root/values/PotMas"/>
            </PotMas>
            <PlaInvCre>
                <FormEditResponse>
                    <xsl:for-each select="Root/values/PlaInvCre">
                        <PlaInvCre>
                            <PesPlaInv>
                                <CanPlaInv>
                                    <xsl:apply-templates select="Cantidad"/>
                                </CanPlaInv>
                                <DesPlaInv>
                                    <xsl:apply-templates select="Descripcion"/>
                                </DesPlaInv>
                                <ValPlaInv>
                                    <xsl:apply-templates select="Valor"/>
                                </ValPlaInv>
                            </PesPlaInv>
                        </PlaInvCre>
                    </xsl:for-each>
                </FormEditResponse>
            </PlaInvCre>
            <TotPlaInvCre>
                <xsl:value-of select="Root/values/TotPlaInvCre"/>
            </TotPlaInvCre>
            <MonSol>
                <xsl:value-of select="Root/values/MonSol"/>
            </MonSol>
            <PlaSol>
                <xsl:value-of select="Root/values/PlaSol"/>
            </PlaSol>
            <PerSol>
                <xsl:value-of select="Root/values/PerSol"/>
            </PerSol>
            <ProCli>
                <xsl:value-of select="Root/values/ProCli"/>
            </ProCli>
            <OtrProCli>
                <xsl:value-of select="Root/values/OtrProCli"/>
            </OtrProCli>
            <MenResCreSol>
                <xsl:value-of select="Root/values/MenResCreSol"/>
            </MenResCreSol>
            <RutForpre>
                <xsl:value-of select="Root/values/RutForpre"/>
            </RutForpre>
            <ReqConSco>
                <xsl:value-of select="Root/values/ReqConSco"/>
            </ReqConSco>
            <CauNegCreSol>
                <xsl:value-of select="Root/values/CauNegCreSol"/>
            </CauNegCreSol>
            <ComCauCreSol>
                <xsl:value-of select="Root/values/ComCauCreSol"/>
            </ComCauCreSol>
            <NumSolCre>
                <xsl:value-of select="Root/values/NumSolCre"/>
            </NumSolCre>
            <CodCli>
                <xsl:value-of select="Root/values/CodCli"/>
            </CodCli>
        </root>
    </xsl:template>
</xsl:stylesheet>