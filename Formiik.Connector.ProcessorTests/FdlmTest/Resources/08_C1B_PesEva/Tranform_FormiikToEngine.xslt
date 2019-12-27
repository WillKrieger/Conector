<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                exclude-result-prefixes="msxsl">
    <xsl:output method="text" indent="yes"/>
    <xsl:template match="root">
        <root>
            {
                "FecEstCre": "<xsl:value-of select="FecEstCre"/>",
                "EfeBanEva": "<xsl:value-of select="EfeBanEva"/>",
                "EfeBanAntEva": "<xsl:value-of select="EfeBanAntEva"/>",
                "CueCobEva": "<xsl:value-of select="CueCobEva"/>",
                "CueCobAntEva": "<xsl:value-of select="CueCobAntEva"/>",
                "IncCueCobEva": "<xsl:value-of select="IncCueCobEva"/>",
                "IncCueCobAntEva": "<xsl:value-of select="IncCueCobAntEva"/>",
                "InvAgrPec": "<xsl:value-of select="InvAgrPec"/>",
                "InvAgrPecAntEva": "<xsl:value-of select="InvAgrPecAntEva"/>",
                "InvPecEspMen": "<xsl:value-of select="InvPecEspMen"/>",
                "InvPecEspMenAntEva": "<xsl:value-of select="InvPecEspMenAntEva"/>",
                "InvMerCom": "<xsl:value-of select="InvMerCom"/>",
                "InvMerComAntEva": "<xsl:value-of select="InvMerComAntEva"/>",
                "InvMatPri": "<xsl:value-of select="InvMatPri"/>",
                "InvMatPriAntEva": "<xsl:value-of select="InvMatPriAntEva"/>",
                "InvPtoPro": "<xsl:value-of select="InvPtoPro"/>",
                "InvPtoProAntEva": "<xsl:value-of select="InvPtoProAntEva"/>",
                "InvPtoTer": "<xsl:value-of select="InvPtoTer"/>",
                "InvPtoTerAntEva": "<xsl:value-of select="InvPtoTerAntEva"/>",
                "TotInvEva": "<xsl:value-of select="TotInvEva"/>",
                "TotInvAntEva": "<xsl:value-of select="TotInvAntEva"/>",
                "TotInvDifEva": "<xsl:value-of select="TotInvDifEva"/>",
                "TotInvPorEva": "<xsl:value-of select="TotInvPorEva"/>",
                "TotActCorEva": "<xsl:value-of select="TotActCorEva"/>",
                "TotActCorAntEva": "<xsl:value-of select="TotActCorAntEva"/>",
                "TotActCorDifEva": "<xsl:value-of select="TotActCorDifEva"/>",
                "TotActCorPorEva": "<xsl:value-of select="TotActCorPorEva"/>",
                "TotActFijEva": "<xsl:value-of select="TotActFijEva"/>",
                "TotActFijAntEva": "<xsl:value-of select="TotActFijAntEva"/>",
                "TotActFijDifEva": "<xsl:value-of select="TotActFijDifEva"/>",
                "TotActFijPorEva": "<xsl:value-of select="TotActFijPorEva"/>",
                "TotActEva": "<xsl:value-of select="TotActEva"/>",
                "TotActAntEva": "<xsl:value-of select="TotActAntEva"/>",
                "TotActDifEva": "<xsl:value-of select="TotActDifEva"/>",
                "TotActPorEva": "<xsl:value-of select="TotActPorEva"/>",
                "CreProEva": "<xsl:value-of select="CreProEva"/>",
                "SalCreProEva": "<xsl:value-of select="SalCreProEva"/>",
                "SalCreProAntEva": "<xsl:value-of select="SalCreProAntEva"/>",
                "CreFunCorPlaEva": "<xsl:value-of select="CreFunCorPlaEva"/>",
                "CreFunCorPlaAntEva": "<xsl:value-of select="CreFunCorPlaAntEva"/>",
                "OtrPasCorEva": "<xsl:value-of select="OtrPasCorEva"/>",
                "OtrPasCorAntEva": "<xsl:value-of select="OtrPasCorAntEva"/>",
                "PasCorEva": "<xsl:value-of select="PasCorEva"/>",
                "PasCorAntEva": "<xsl:value-of select="PasCorAntEva"/>",
                "PasCorDifEva": "<xsl:value-of select="PasCorDifEva"/>",
                "PasCorPorEva": "<xsl:value-of select="PasCorPorEva"/>",
                "CreFdlLarPlaEva": "<xsl:value-of select="CreFdlLarPlaEva"/>",
                "CreFdlLarPlaAntEva": "<xsl:value-of select="CreFdlLarPlaAntEva"/>",
                "OtrPasNoCorEva": "<xsl:value-of select="OtrPasNoCorEva"/>",
                "OtrPasNoCorAntEva": "<xsl:value-of select="OtrPasNoCorAntEva"/>",
                "PasNoCorEva": "<xsl:value-of select="PasNoCorEva"/>",
                "PasNoCorAntEva": "<xsl:value-of select="PasNoCorAntEva"/>",
                "TotPasEva": "<xsl:value-of select="TotPasEva"/>",
                "TotPasAntEva": "<xsl:value-of select="TotPasAntEva"/>",
                "TotPasDifEva": "<xsl:value-of select="TotPasDifEva"/>",
                "TotPasPorEva": "<xsl:value-of select="TotPasPorEva"/>",
                "TotPatEva": "<xsl:value-of select="TotPatEva"/>",
                "TotPatAntEva": "<xsl:value-of select="TotPatAntEva"/>",
                "TotPatDifEva": "<xsl:value-of select="TotPatDifEva"/>",
                "TotPatPorEva": "<xsl:value-of select="TotPatPorEva"/>",
                "TotActFamEva": "<xsl:value-of select="TotActFamEva"/>",
                "TotActFamAntEva": "<xsl:value-of select="TotActFamAntEva"/>",
                "TotActFamDifEva": "<xsl:value-of select="TotActFamDifEva"/>",
                "TotActFamPorEva": "<xsl:value-of select="TotActFamPorEva"/>",
                "TotPasFamEva": "<xsl:value-of select="TotPasFamEva"/>",
                "TotPasFamAntEva": "<xsl:value-of select="TotPasFamAntEva"/>",
                "TotPasFamDifEva": "<xsl:value-of select="TotPasFamDifEva"/>",
                "TotPasFamPorEva": "<xsl:value-of select="TotPasFamPorEva"/>",
                "PatFamEva": "<xsl:value-of select="PatFamEva"/>",
                "PatFamAntEva": "<xsl:value-of select="PatFamAntEva"/>",
                "PatFamDifEva": "<xsl:value-of select="PatFamDifEva"/>",
                "PatFamPorEva": "<xsl:value-of select="PatFamPorEva"/>",
                "PatConNegFamEva": "<xsl:value-of select="PatConNegFamEva"/>",
                "PatConNegFamAntEva": "<xsl:value-of select="PatConNegFamAntEva"/>",
                "PatConNegFamDifEva": "<xsl:value-of select="PatConNegFamDifEva"/>",
                "PatConNegFamPorEva": "<xsl:value-of select="PatConNegFamPorEva"/>",
                "SecFluIngEgr": "<xsl:value-of select="SecFluIngEgr"/>",
                "VenConEva": "<xsl:value-of select="VenConEva"/>",
                "VenConAntEva": "<xsl:value-of select="VenConAntEva"/>",
                "VenConDifEva": "<xsl:value-of select="VenConDifEva"/>",
                "VenConPorEva": "<xsl:value-of select="VenConPorEva"/>",
                "RecCarEva": "<xsl:value-of select="RecCarEva"/>",
                "RecCarAntEva": "<xsl:value-of select="RecCarAntEva"/>",
                "CosVenEva": "<xsl:value-of select="CosVenEva"/>",
                "CosVenAntEva": "<xsl:value-of select="CosVenAntEva"/>",
                "SalEva": "<xsl:value-of select="SalEva"/>",
                "SalAntEva": "<xsl:value-of select="SalAntEva"/>",
                "GasGenEva": "<xsl:value-of select="GasGenEva"/>",
                "GasGenAntEva": "<xsl:value-of select="GasGenAntEva"/>",
                "OblFinEva": "<xsl:value-of select="OblFinEva"/>",
                "OblFinAntEva": "<xsl:value-of select="OblFinAntEva"/>",
                "OblFinDifEva": "<xsl:value-of select="OblFinDifEva"/>",
                "OblFinPorEva": "<xsl:value-of select="OblFinPorEva"/>",
                "IngLiqEva": "<xsl:value-of select="IngLiqEva"/>",
                "IngLiqAntEva": "<xsl:value-of select="IngLiqAntEva"/>",
                "IngLiqDifEva": "<xsl:value-of select="IngLiqDifEva"/>",
                "IngLiqPorEva": "<xsl:value-of select="IngLiqPorEva"/>",
                "OtrIngFamEva": "<xsl:value-of select="OtrIngFamEva"/>",
                "OtrIngFamAntEva": "<xsl:value-of select="OtrIngFamAntEva"/>",
                "GasOblFamEva": "<xsl:value-of select="GasOblFamEva"/>",
                "GasOblFamAntEva": "<xsl:value-of select="GasOblFamAntEva"/>",
                "SecIndFin": "<xsl:value-of select="SecIndFin"/>",
                "LiqDisEva": "<xsl:value-of select="LiqDisEva"/>",
                "LiqDisAntEva": "<xsl:value-of select="LiqDisAntEva"/>",
                "LiqDisDifEva": "<xsl:value-of select="LiqDisDifEva"/>",
                "LiqDisPorEva": "<xsl:value-of select="LiqDisPorEva"/>",
                "CapTraEva": "<xsl:value-of select="CapTraEva"/>",
                "CapTraAntEva": "<xsl:value-of select="CapTraAntEva"/>",
                "RazCorEva": "<xsl:value-of select="RazCorEva"/>",
                "RazCorAntEva": "<xsl:value-of select="RazCorAntEva"/>",
                "MarBruEva": "<xsl:value-of select="MarBruEva"/>",
                "MarBruAntEva": "<xsl:value-of select="MarBruAntEva"/>",
                "EndEva": "<xsl:value-of select="EndEva"/>",
                "EndAntEva": "<xsl:value-of select="EndAntEva"/>",
                "LiqCubEva": "<xsl:value-of select="LiqCubEva"/>",
                "LiqCubAntEva": "<xsl:value-of select="LiqCubAntEva"/>",
                "FecAna": "<xsl:value-of select="FecAna"/>",
                "FecAnaAnt": "<xsl:value-of select="FecAnaAnt"/>",
                "FecAnaDif": "<xsl:value-of select="FecAnaDif"/>",
                "PatNeg": "<xsl:value-of select="PatNeg"/>",
                "PatNegAnt": "<xsl:value-of select="PatNegAnt"/>",
                "PatNegDif": "<xsl:value-of select="PatNegDif"/>",
                "PatCon": "<xsl:value-of select="PatCon"/>",
                "PatConAnt": "<xsl:value-of select="PatConAnt"/>",
                "PatConDif": "<xsl:value-of select="PatConDif"/>",
                "LiqDis": "<xsl:value-of select="LiqDis"/>",
                "LiqDisAnt": "<xsl:value-of select="LiqDisAnt"/>",
                "LiqDisDif": "<xsl:value-of select="LiqDisDif"/>",
                "OblFinEst": "<xsl:value-of select="OblFinEst"/>",
                "ProLiqDis": "<xsl:value-of select="ProLiqDis"/>",
                "MesTraAnaAnt": "<xsl:value-of select="MesTraAnaAnt"/>",
                "TotLiqNPer": "<xsl:value-of select="TotLiqNPer"/>",
                "PatConAnaAnt": "<xsl:value-of select="PatConAnaAnt"/>",
                "TotLiqNPerPatAnt": "<xsl:value-of select="TotLiqNPerPatAnt"/>",
                "ParConAnaAct": "<xsl:value-of select="ParConAnaAct"/>",
                "ExcJus": "<xsl:value-of select="ExcJus"/>"
            }
        </root>
    </xsl:template>
</xsl:stylesheet>
