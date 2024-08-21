select 
        ven.id_planilha
        ,ven.id_operacao
        ,ven.nro_linha
        ,ven.cod_emp
        ,ven.local
        ,ven.id_parc
        ,ven.cnpj_cpf
        ,ven.uf
        ,ven.chave_acesso
        ,ven.nro_doc
        ,ven.nro_item
        ,ven.nro_posicao
        ,ven.dt_doc
        ,ven.dt_lanc
        ,ven.dt_ref
        ,ven.cfop
        ,ven.origem
        ,ven.sit_trib
        ,ven.material
        ,ven.tp_aval
        ,ven.cod_controle
        ,ven.denom
        ,ven.unid
        ,ven.quantidade_1
        ,ven.qtd_conv
        ,ven.preco_liq
        ,ven.liquido
        ,ven.valor
        ,ven.vlr_contb
        ,ven.pis_base
        ,ven.stpis
        ,ven.pis_taxa
        ,ven.pis_vlr
        ,ven.stcof
        ,ven.cof_base
        ,ven.cof_taxa
        ,ven.cof_vlr
        ,ven.ipi_base
        ,ven.ipi_taxa
        ,ven.ipi_vlr
        ,ven.icms_base
        ,ven.icms_taxa
        ,ven.icms_vlr
        ,ven.fecp_vlr
        ,ven.icst_base
        ,ven.icst_taxa
        ,ven.icst_valor
        ,ven.fest_valor
        ,ven.bc_icms_rt
        ,ven.vlr_icms_str
        ,ven.vlr_fcps_st_rt
        ,ven.doc_origem
        ,ven.item_ref
        ,ven.saldo
        ,ven.status
        ,ven.qtd_dev
        ,'<== ==>' as ENTRADA_SAIDA
        ,con.qtd_e as QTD_USADA
        ,ent.id_planilha
        ,ent.id_operacao
        ,ent.nro_linha
        ,ent.cod_emp
        ,ent.local
        ,ent.id_parc
        ,ent.cnpj_cpf
        ,ent.uf
        ,ent.chave_acesso
        ,ent.nro_doc
        ,ent.nro_item
        ,ent.nro_posicao
        ,ent.dt_doc
        ,ent.dt_lanc
        ,ent.dt_ref
        ,ent.cfop
        ,ent.origem
        ,ent.sit_trib
        ,ent.material
        ,ent.tp_aval
        ,ent.cod_controle
        ,ent.denom
        ,ent.unid
        ,ent.quantidade_1
        ,ent.qtd_conv
        ,ent.preco_liq
        ,ent.liquido
        ,ent.valor
        ,ent.vlr_contb
        ,ent.pis_base
        ,ent.stpis
        ,ent.pis_taxa
        ,ent.pis_vlr
        ,ent.stcof
        ,ent.cof_base
        ,ent.cof_taxa
        ,ent.cof_vlr
        ,ent.ipi_base
        ,ent.ipi_taxa
        ,ent.ipi_vlr
        ,ent.icms_base
        ,ent.icms_taxa
        ,ent.icms_vlr
        ,ent.fecp_vlr
        ,ent.icst_base
        ,ent.icst_taxa
        ,ent.icst_valor
        ,ent.fest_valor
        ,ent.bc_icms_rt
        ,ent.vlr_icms_str
        ,ent.vlr_fcps_st_rt
        ,ent.doc_origem
        ,ent.item_ref
        ,ent.saldo
        ,ent.status
        ,ent.qtd_dev
        ,val.*
from controle_e con
    left JOIN 
    nfe_det_trade ven 
    ON  ven.id_planilha = con.id_s AND ven.nro_linha = con.nro_linha_s
    left JOIN 
    nfe_det_trade ent 
    ON ent.id_planilha = con.id_e  AND ent.nro_linha = con.nro_linha_e
    left join nfe_det_trade_val val
    ON val.id_grupo = con.id_grupo 
      and (val.id = con.id_s and val.nro_linha = con.nro_linha_s )
      and (val.id_planilha_entrada = con.id_e and val.nro_linha_entrada = con.nro_linha_e)
order by ven.cod_emp,ven.local,ven.dt_ref,ven.nro_doc
   -- where con.id_s = 26 and con.nro_linha_s = 6143

select * from nfe_det_trade_val

select * from nfe_det_trade where id_planilha = 26 and nro_linha = 6143 union all
select * from nfe_det_trade where id_planilha = 1  and nro_linha = 3162

select * from controle_e where id_s = 26 and nro_linha_s = 6143

select * from nfe_det_trade_val where id_grupo = 1 
         and (id = 26 and nro_linha = 6143)
         and (id_planilha_entrada = 1 and nro_linha_entrada = 3162)