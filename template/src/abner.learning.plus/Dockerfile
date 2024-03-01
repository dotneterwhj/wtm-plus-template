FROM 192.168.1.192/base/dotnet/aspnet:6.0
WORKDIR /app
RUN ln -sf /usr/share/zoneinfo/Asia/Shanghai /etc/localtime;\ 
    echo 'Asia/Shanghai' >/etc/timezone
RUN echo '[system_default_sect]\nMinProtocol = TLSv1\nCipherString = DEFAULT@SECLEVEL=1' > /etc/ssl/openssl.cnf
COPY . /app/
ENTRYPOINT ["dotnet", "abner.learning.plus.dll"]