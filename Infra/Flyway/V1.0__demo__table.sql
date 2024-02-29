CREATE USER start_up_app with password 'postgres';
GRANT CONNECT ON DATABASE "start-up-local" TO start_up_app;

CREATE SCHEMA demo_schema;
GRANT USAGE ON SCHEMA demo_schema TO start_up_app;

CREATE TABLE demo_schema.demo_data
(
    id              UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    date            date NOT NULL,
    ui_value        text,
    button_click    bool,
    language        text,
    favorite_number INT
);
