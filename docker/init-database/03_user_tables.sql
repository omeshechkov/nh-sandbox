\connect sandbox_db;

create table public.users
(
    id          bigserial    not null,
    name        varchar(255) not null,
    surname     varchar(255) not null,
    middle_name varchar(255) null,

    constraint pk_users primary key (id)
);

alter table public.users
    owner to sys;

create table public.user_accounts
(
    id       bigserial not null,
    user_id  bigint    not null,
    currency char(3)   not null,
    balance  decimal   not null,

    constraint pk_user_accounts primary key (id),

    constraint "fk_user_accounts#user" foreign key (user_id)
        references public.users (id)
);

alter table public.user_accounts
    owner to sys;

