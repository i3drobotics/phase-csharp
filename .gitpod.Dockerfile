FROM gitpod/workspace-dotnet

USER gitpod
# Dazzle does not rebuild a layer until one of its lines are changed. Increase this counter to rebuild this layer.
ENV TRIGGER_REBUILD=1

# Install .NET SDK (Current channel)
# Source: https://docs.microsoft.com/dotnet/core/install/linux-scripted-manual#scripted-install
RUN mkdir -p /home/gitpod/dotnet && curl -fsSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --version 5.0.408 --install-dir /home/gitpod/dotnet
ENV DOTNET_ROOT=/home/gitpod/dotnet
ENV PATH=/home/gitpod/dotnet:$PATH

# TODO(toru): Remove this hack when the kernel bug is resolved.
#             ref. https://github.com/gitpod-io/gitpod/issues/8901
RUN bash \
    && { echo 'if [ ! -z $GITPOD_REPO_ROOT ]; then'; \
        echo '\tCONTAINER_DIR=$(awk '\''{ print $6 }'\'' /proc/self/maps | grep ^\/run\/containerd | head -n 1 | cut -d '\''/'\'' -f 1-6)'; \
        echo '\tif [ ! -z $CONTAINER_DIR ]; then'; \
        echo '\t\t[[ ! -d $CONTAINER_DIR ]] && sudo mkdir -p $CONTAINER_DIR && sudo ln -s / $CONTAINER_DIR/rootfs'; \
        echo '\tfi'; \
        echo 'fi'; } >> /home/gitpod/.bashrc.d/110-dotnet
RUN chmod +x /home/gitpod/.bashrc.d/110-dotnet
RUN sudo apt update && \
    sudo apt install -y doxygen && \
    curl --output phase.deb -L https://github.com/i3drobotics/phase/releases/download/v0.3.0/phase-v0.3.0-ubuntu-20.04-x86_64.deb && \
    sudo apt install -y ./phase.deb