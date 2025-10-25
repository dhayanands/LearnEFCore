FROM mcr.microsoft.com/devcontainers/base:ubuntu

# Set up the working directory
WORKDIR /usr/share/dotnet

# Download and extract the .NET SDK tarball
RUN wget https://builds.dotnet.microsoft.com/dotnet/Sdk/10.0.100-rc.2.25502.107/dotnet-sdk-10.0.100-rc.2.25502.107-linux-x64.tar.gz \
    && tar zxf dotnet-sdk-10.0.100-rc.2.25502.107-linux-x64.tar.gz -C /usr/share/dotnet \
    && rm dotnet-sdk-10.0.100-rc.2.25502.107-linux-x64.tar.gz

# Set environment variables for .NET (system-wide)
ENV DOTNET_ROOT=/usr/share/dotnet
ENV PATH="${PATH}:/usr/share/dotnet"

# Switch to the vscode user for installing global tools
USER vscode

# Install dotnet-ef tool as the vscode user (this will create /home/vscode/.dotnet/tools if needed)
RUN dotnet tool install --global dotnet-ef

# Update PATH to include the vscode user's global tools directory
ENV PATH="${PATH}:/home/vscode/.dotnet/tools"

# Verify installation of dotnet-ef (as vscode user)
RUN dotnet-ef --version