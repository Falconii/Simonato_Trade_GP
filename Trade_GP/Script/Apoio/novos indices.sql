CREATE INDEX indice_sai_dev
	ON public.nfe_det_trade USING btree (id_grupo int4_ops, id_operacao bpchar_ops, id_saida int4_ops, nro_linha_saida int4_ops)
GO
CREATE INDEX indice_dev_saida
	ON public.nfe_det_trade USING btree (id_grupo int4_ops, cod_emp text_ops, local text_ops, cfop bpchar_ops, id_operacao bpchar_ops, nro_doc text_ops, material text_ops)
GO
CREATE INDEX indice_dev_entrada
	ON public.nfe_det_trade USING btree (id_grupo int4_ops, cod_emp text_ops, local text_ops, id_operacao bpchar_ops, dt_ref date_ops)
GO
