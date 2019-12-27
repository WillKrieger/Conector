<?xml version="1.0" encoding="utf-8"?><xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"><xsl:output method="text" indent="yes"/><xsl:template match="root"><root>{
    "Cliente": {
        "PriApeCli": "<xsl:value-of select="PriApeCli"/>",
        "SegApeCli": "<xsl:value-of select="SegApeCli"/>",
        "PriNomCli": "<xsl:value-of select="PriNomCli"/>",
        "SegNomCli": "<xsl:value-of select="SegNomCli"/>",
        "FecNacCli": "<xsl:value-of select="FecNacCli"/>",
        "GenCli": [
            "<xsl:value-of select="GenCli"/>"
        ],
        "EstCivCli": [
            "<xsl:value-of select="EstCivCli"/>"
        ]
    },
    "LugNacCli": "<xsl:value-of select="LugNacCli"/>",
    "FecExpIdeCli": "<xsl:value-of select="FecExpIdeCli"/>",
    "NcnCli": [
        "<xsl:value-of select="NcnCli"/>"
    ],
    "LugExpIdeCli": "<xsl:value-of select="LugExpIdeCli"/>",
    "NcnCli": "<xsl:value-of select="NcnCli"/>",
    "TieOtrNacCli": "<xsl:value-of select="TieOtrNacCli"/>",
    "OtrNacCli": "<xsl:value-of select="OtrNacCli"/>",
    "TieResOtrPaiCli": "<xsl:value-of select="TieResOtrPaiCli"/>",
    "OtrPaiResCli": [
        "<xsl:value-of select="OtrPaiResCli"/>"
    ],
    "OblTriCli": "<xsl:value-of select="OblTriCli"/>",
    "TinCli": "<xsl:value-of select="TinCli"/>",
    "Conyuge": {
        "PriApeCon": "<xsl:value-of select="PriApeCon"/>",
        "SegApeCon": "<xsl:value-of select="SegApeCon"/>",
        "PriNomCon": "<xsl:value-of select="PriNomCon"/>",
        "SegNomCon": "<xsl:value-of select="SegNomCon"/>"
    },
    "IdConyuge": {
        "NumIdeCon": "<xsl:value-of select="NumIdeCon"/>",
        "TipIdeCon": [
            "<xsl:value-of select="TipIdeCon"/>"
        ]
    },
    "OcuCon": [
        "<xsl:value-of select="OcuCon"/>"
    ],
    "TieHij": [
        "<xsl:value-of select="TieHij"/>"
    ],
    "PerCarCli": "<xsl:value-of select="PerCarCli"/>",
    "DilComFam": "<xsl:value-of select="DilComFam"/>",
    "ComFam": [<xsl:for-each select="ComFam/FormEditResponse/ComFam">{
            "ComTipFam": ["<xsl:value-of select="ComTipFam"/>"],
            "ComEdadFam": "<xsl:value-of select="ComEdadFam"/>",
            "ComNivFam": ["<xsl:value-of select="ComNivFam"/>"],
            "ComUltFam": "<xsl:value-of select="ComUltFam"/>"
        }</xsl:for-each>
    ],
    "TipSalCli": [
        "<xsl:value-of select="TipSalCli"/>"
    ],
    "DirResCli": "<xsl:value-of select="DirResCli"/>",
    "IdeBarResCli": [
        "<xsl:value-of select="IdeBarResCli"/>"
    ],
    "EtrCli": [
        "<xsl:value-of select="EtrCli"/>"
    ],
    "TipNumCon": [
        "<xsl:value-of select="TipNumCon"/>"
    ],
    "TelCli": "<xsl:value-of select="TelCli"/>",
    "CelCli": "<xsl:value-of select="CelCli"/>",
    "TipVivCli": [
        "<xsl:value-of select="TipVivCli"/>"
    ],
    "TipVivCli": "<xsl:value-of select="TipVivCli"/>",
    "MesPerVivCli": "<xsl:value-of select="MesPerVivCli"/>",
    "NomArrVivCli": "<xsl:value-of select="NomArrVivCli"/>",
    "TelArrVivCli": "<xsl:value-of select="TelArrVivCli"/>",
    "CanArrVivCli": "<xsl:value-of select="CanArrVivCli"/>",
    "CorEleCli": "<xsl:value-of select="CorEleCli"/>",
    "NivEduCli": [
        "<xsl:value-of select="NivEduCli"/>"
    ],
    "UltAnoCur": "<xsl:value-of select="UltAnoCur"/>",
    "OcuCli": [
        "<xsl:value-of select="OcuCli"/>"
    ],
    "EsCliPep": "<xsl:value-of select="EsCliPep"/>",
    "EstVinLabCli": "<xsl:value-of select="EstVinLabCli"/>",
    "NomEmpLabCli": "<xsl:value-of select="NomEmpLabCli"/>",
    "DirEmpLabCli": "<xsl:value-of select="DirEmpLabCli"/>",
    "CiuEmpLabCli": "<xsl:value-of select="CiuEmpLabCli"/>",
    "TelEmpLabCli": "<xsl:value-of select="TelEmpLabCli"/>",
    "FaxEmpLabCli": "<xsl:value-of select="FaxEmpLabCli"/>",
    "NegEnDom": "<xsl:value-of select="NegEnDom"/>",
    "TipLocNeg": [
        "<xsl:value-of select="TipLocNeg"/>"
    ],
    "NomArrNeg": "<xsl:value-of select="NomArrNeg"/>",
    "TelArrNeg": "<xsl:value-of select="TelArrNeg"/>",
    "CanArrNeg": "<xsl:value-of select="CanArrNeg"/>",
    "NomNeg": "<xsl:value-of select="NomNeg"/>",
    "DirNeg": "<xsl:value-of select="DirNeg"/>",
    "IdAgencia": "<xsl:value-of select="IdAgencia"/>",
    "IdeBarNeg": "<xsl:value-of select="IdeBarNeg"/>",
    "TipNumConNeg": [
        "<xsl:value-of select="TipNumConNeg"/>"
    ],
    "TelNeg": "<xsl:value-of select="TelNeg"/>",
    "CelNeg": "<xsl:value-of select="CelNeg"/>",
    "RegCamComNeg": "<xsl:value-of select="RegCamComNeg"/>",
    "TieFunNeg": "<xsl:value-of select="TieFunNeg"/>",
    "IdeAct": [
        "<xsl:value-of select="IdeAct"/>"
    ],
    "NumEmpNeg": "<xsl:value-of select="NumEmpNeg"/>",
    "TipCre": [
        "<xsl:value-of select="TipCre"/>",
        "<xsl:value-of select="Pro"/>",
        "<xsl:value-of select="FrePag"/>"
    ],
    "MonSol": "<xsl:value-of select="MonSol"/>",
    "PlaSol": "<xsl:value-of select="PlaSol"/>",
    "EsRee": "<xsl:value-of select="EsRee"/>",
    "CanCreARee": "<xsl:value-of select="CanCreARee"/>",
    "NumCreReeRad1": "<xsl:value-of select="NumCreReeRad1"/>",
    "NumCreReeRad2": "<xsl:value-of select="NumCreReeRad2"/>",
    "NumCreReeRad3": "<xsl:value-of select="NumCreReeRad3"/>",
    "NumCreReeRad4": "<xsl:value-of select="NumCreReeRad4"/>",
    "NumCreReeRad5": "<xsl:value-of select="NumCreReeRad5"/>",
    "NumCreRee1": "<xsl:value-of select="NumCreRee1"/>",
    "SalCreRee1": "<xsl:value-of select="SalCreRee1"/>",
    "NumCreRee2": "<xsl:value-of select="NumCreRee2"/>",
    "SalCreRee2": "<xsl:value-of select="SalCreRee2"/>",
    "NumCreRee3": "<xsl:value-of select="NumCreRee3"/>",
    "SalCreRee3": "<xsl:value-of select="SalCreRee3"/>",
    "NumCreRee4": "<xsl:value-of select="NumCreRee4"/>",
    "SalCreRee4": "<xsl:value-of select="SalCreRee4"/>",
    "NumCreRee5": "<xsl:value-of select="NumCreRee5"/>",
    "SalCreRee5": "<xsl:value-of select="SalCreRee5"/>",
    "OriSolCre": [
        "<xsl:value-of select="OriSolCre"/>"
    ]
}</root></xsl:template></xsl:stylesheet>