# Auth

    SignupRequest {
        FirstName ,
        Last Name ,
        Role ,
        Email ,
        Pasword

    }

    LoginRequest {
        Email ,
        Password

    }

    AuthReponse{
        SignUpResponse {
            Id ,
            Email ,
            FirstName ,
            LastName ,
            Email ,
            Token
        }

        LoginResponse {
            Id ,
            Email ,
            FirstName ,
            LastName ,
            Email ,
            Token
    }
    }
