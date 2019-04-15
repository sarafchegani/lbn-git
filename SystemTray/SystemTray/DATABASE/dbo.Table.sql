﻿CREATE TABLE [dbo].[Table] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [bcf]           NVARCHAR(50)          NULL,
    [bcf_adm_state] VARCHAR (50) NULL,
    [bcf_op_state]  VARCHAR (50) NULL,
    [seg]           VARCHAR (50) NULL,
    [seg_name]      VARCHAR (50) NULL,
    [bts]           VARCHAR(50)          NULL,
    [btsname]       VARCHAR (50) NULL,
    [bts_adm_state] VARCHAR (50) NULL,
    [bts_op_state]  VARCHAR (50) NULL,
    [trx]           VARCHAR (50) NULL,
    [edge]          VARCHAR (50) NULL,
    [trx_adm_state] VARCHAR (50) NULL,
    [trx_op_state]  VARCHAR (50) NULL,
    [bcsu]          VARCHAR (50) NULL,
    [dch_numb]      VARCHAR (50) NULL,
    [dch_name]      VARCHAR (50) NULL,
    [ch0_type]      VARCHAR (50) NULL,
    [ch0_adm_state] VARCHAR (50) NULL,
    [ch0_op_state]  VARCHAR (50) NULL,
    [ch1_type]      VARCHAR (50) NULL,
    [ch1_adm_state] VARCHAR (50) NULL,
    [ch1_op_state]  VARCHAR (50) NULL,
    [ch2_type]      VARCHAR (50) NULL,
    [ch2_adm_state] VARCHAR (50) NULL,
    [ch2_op_state]  VARCHAR (50) NULL,
    [ch3_adm_state] VARCHAR (50) NULL,
    [ch3_op_state]  VARCHAR (50) NULL,
    [ch3_type]      VARCHAR (50) NULL,
    [ch4_type]      VARCHAR (50) NULL,
    [ch4_adm_state] VARCHAR (50) NULL,
    [ch4_op_state]  VARCHAR (50) NULL,
    [ch5_type]      VARCHAR (50) NULL,
    [ch5_adm_state] VARCHAR (50) NULL,
    [ch5_op_state]  VARCHAR (50) NULL,
    [ch6_type]      VARCHAR (50) NULL,
    [ch6_adm_state] VARCHAR (50) NULL,
    [ch6_op_state]  VARCHAR (50) NULL,
    [ch7_type]      VARCHAR (50) NULL,
    [ch7_adm_state] VARCHAR (50) NULL,
    [ch7_op_state]  VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
